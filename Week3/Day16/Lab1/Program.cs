using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO 1: ZIP Code
            string zipPattern = @"^\d{5}(-\d{4})?$";

            Console.WriteLine(
                $"ZIP \"12345\": {Regex.IsMatch("12345", zipPattern)} | " +
                $"\"12345-6789\": {Regex.IsMatch("12345-6789", zipPattern)} | " +
                $"\"1234\": {Regex.IsMatch("1234", zipPattern)}"
            );


            // TODO 2: Username
            // 3-16 characters, only letters/digits/underscore,
            // and must not start with a digit.
            string usernamePattern = @"^[A-Za-z_][A-Za-z0-9_]{2,15}$";

            Console.WriteLine(
                $"Username \"user_1\": {Regex.IsMatch("user_1", usernamePattern)} | " +
                $"\"1user\": {Regex.IsMatch("1user", usernamePattern)} | " +
                $"\"ab\": {Regex.IsMatch("ab", usernamePattern)}"
            );


            // TODO 3: Hex Color
            string hexPattern = @"^#[0-9A-Fa-f]{6}$";

            Console.WriteLine(
                $"Hex \"#1A2B3C\": {Regex.IsMatch("#1A2B3C", hexPattern)} | " +
                $"\"#GGGGGG\": {Regex.IsMatch("#GGGGGG", hexPattern)} | " +
                $"\"1A2B3C\": {Regex.IsMatch("1A2B3C", hexPattern)}"
            );


            // TODO 4: Password
            // Using multiple Regex checks instead of one giant pattern.
            // This makes each password requirement easier to understand.

            string passwordLengthPattern = @"^.{8,}$";
            string digitPattern = @"\d";
            string uppercasePattern = @"[A-Z]";

            string[] passwords =
            {
                "password",
                "Password1",
                "pass1"
            };

            foreach (string password in passwords)
            {
                bool validPassword =
                    Regex.IsMatch(password, passwordLengthPattern) &&
                    Regex.IsMatch(password, digitPattern) &&
                    Regex.IsMatch(password, uppercasePattern);

                Console.WriteLine($"Password \"{password}\": {validPassword}");
            }


            // TODO 5: Sentence
            // Allows normal letters, spaces and words.
            // Exactly one final '.', '!' or '?' is required.
            string sentencePattern = @"^[A-Za-z ]+[.!?]$";

            Console.WriteLine(
                $"Sentence \"Hello there.\": {Regex.IsMatch("Hello there.", sentencePattern)} | " +
                $"\"Wait...\": {Regex.IsMatch("Wait...", sentencePattern)} | " +
                $"\"Really?\": {Regex.IsMatch("Really?", sentencePattern)}"
            );


            // Bonus
            Console.WriteLine("\nBonus Validation:");

            List<string> errors = ValidateSignup("user_1", "Password1");

            if (errors.Count == 0)
            {
                Console.WriteLine("Signup is valid.");
            }
            else
            {
                foreach (string error in errors)
                {
                    Console.WriteLine(error);
                }
            }
        }


        static List<string> ValidateSignup(string username, string password)
        {
            List<string> errors = new List<string>();

            string usernamePattern = @"^[A-Za-z_][A-Za-z0-9_]{2,15}$";

            if (!Regex.IsMatch(username, usernamePattern))
            {
                errors.Add("Invalid username.");
            }

            bool validPassword =
                Regex.IsMatch(password, @"^.{8,}$") &&
                Regex.IsMatch(password, @"\d") &&
                Regex.IsMatch(password, @"[A-Z]");

            if (!validPassword)
            {
                errors.Add(
                    "Password must be at least 8 characters long, " +
                    "contain one digit and one uppercase letter."
                );
            }

            return errors;
        }
    }
}