using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using LabsLibrary;
using McMaster.Extensions.CommandLineUtils;
using static LabsLibrary.pr1;

namespace CrossPlatformLab4
{
    public class Program
    {
        public const string LabPathEnvVariableName = "LAB_PATH";

        public static void Main(string[] args)
        {
            
            var app = new CommandLineApplication();

            app.HelpOption();

            app.Command("version", (versionCommand) =>
            {
                versionCommand.Description = "Shows the version and author name";
                versionCommand.HelpOption();
                versionCommand.OnExecute(() =>
                {
                    Console.WriteLine($"Version: {typeof(Program).Assembly.GetName().Version}");
                    Console.WriteLine("Author: Bilousova Nataliia");
                });
            });

            app.Command("run", (runCommand) =>
            {
                runCommand.Description = "Runs the specifed lab work";
                runCommand.HelpOption();

                for (int i = 1; i <= 3; i++)
                {
                    runCommand.Command($"lab{i}", (labCommand) =>
                    {
                        labCommand.Description = $"Runs the {labCommand.Name}";
                        labCommand.HelpOption();
                        var inputOption = labCommand.Option("-i|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                        var outputOption = labCommand.Option("-o|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                        labCommand.OnExecute(() =>
                        {
                            OnLabCommandExecute(labCommand, inputOption, outputOption);
                        });
                    });
                }
            });

            app.Command("set-path", (setPathCommand) =>
            {
                setPathCommand.Description = $"Sets the envinroment variable {LabPathEnvVariableName}";
                setPathCommand.HelpOption();
                var pathOption = setPathCommand.Option("-p|--path <PATH>", "Envinroment variable folder path for IO files",
                    CommandOptionType.SingleValue).IsRequired();
                setPathCommand.OnExecute(() =>
                {
                    var pathValue = pathOption.Value();
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        var myToolPath = Path.Combine("/etc", "profile.d", "my-tool.sh");
                        GetOrSetEnvironmentVariableLinux(myToolPath, $"export {LabPathEnvVariableName}={pathValue} {Environment.NewLine}");
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        var bashProfilePath = Path.Combine("/Users", "vagrant", ".bash_profile");
                        GetOrSetEnvironmentVariableLinux(bashProfilePath, $"export {LabPathEnvVariableName}={pathValue} {Environment.NewLine}");
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        Environment.SetEnvironmentVariable(LabPathEnvVariableName, pathValue, EnvironmentVariableTarget.User);
                    }

                    Console.WriteLine($"Envinroment variable {LabPathEnvVariableName} was added with value \"{pathValue}\"");
                });
            });

            app.Command("remove-path", (removePathCommand) =>
            {
                removePathCommand.Description = $"Removes the envinroment variable {LabPathEnvVariableName}";
                removePathCommand.HelpOption();
                removePathCommand.OnExecute(() =>
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        var myToolPath = Path.Combine("/etc", "profile.d", "my-tool.sh");
                        GetOrSetEnvironmentVariableLinux(myToolPath, $"unset {LabPathEnvVariableName} {Environment.NewLine}");
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        var bashProfilePath = Path.Combine("/Users", "vagrant", ".bash_profile");
                        GetOrSetEnvironmentVariableLinux(bashProfilePath, $"unset {LabPathEnvVariableName} {Environment.NewLine}");
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        Environment.SetEnvironmentVariable(LabPathEnvVariableName, null, EnvironmentVariableTarget.User);
                    }

                    Console.WriteLine($"Envinroment variable {LabPathEnvVariableName} was removed");
                });
            });

            app.OnExecute(() =>
            {
                app.ShowHelp();
            });

            try
            {
                app.Execute(args);
            }
            catch (Exception exception)
            {
                app.ShowHelp();
                Console.WriteLine("Exception: " + exception.Message);
            }
        }

        private static void OnLabCommandExecute(CommandLineApplication labCommand,
            CommandOption inputOption, CommandOption outputOption)
        {
            var inputPath = GetPath(inputOption);
            var outputPath = GetPath(outputOption);

            var inputLines = File.ReadAllLines(inputPath);
            switch (labCommand.Name)
            {
                case "lab1":
                    File.WriteAllLines(outputPath, new pr1().GetResult(inputLines));
                    break;
                case "lab2":
                    File.WriteAllLines(outputPath, new Lab2().GetResult(inputLines));
                    break;
                //case "lab3":
                //    File.WriteAllText(outputPath, new Lab3().GetResult(inputLines));
                //    break;
                default:
                    throw new ArgumentException($"{labCommand.Name} not found");
            }

            Console.WriteLine($"The result was saved in {outputPath}");
        }

        private static string GetPath(CommandOption pathOption)
        {
            if (File.Exists(pathOption.Value()))
                return pathOption.Value();

            var labPathEnvVariable = Environment.GetEnvironmentVariable(LabPathEnvVariableName, EnvironmentVariableTarget.User);
            string fileName = pathOption.ShortName == "i" ? "Input.txt" : "Output.txt";
            if (labPathEnvVariable != null)
            {
                var pathWithEnvVar = Path.Combine(labPathEnvVariable, fileName);
                if (File.Exists(pathWithEnvVar))
                    return pathWithEnvVar;
            }

            string homePath = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            var path = Path.Combine(homePath, fileName);
            if (File.Exists(path))
                return path;

            throw new ArgumentException($"{fileName} not found");
        }

        private static void GetOrSetEnvironmentVariableLinux(string pathToFileWithVariable, string commandToAddInsideShFile)
        {
            File.AppendAllText(pathToFileWithVariable, commandToAddInsideShFile);
            var updateProcess = new Process()
            {
                StartInfo = new ProcessStartInfo("/bin/bash", $"-c \"source {pathToFileWithVariable}\";bash;exit;exit")
                {
                    UseShellExecute = true,
                }
            };

            updateProcess.Start();
            updateProcess.WaitForExit();
            updateProcess.Close();
            updateProcess.Dispose();
        }
    }
}
