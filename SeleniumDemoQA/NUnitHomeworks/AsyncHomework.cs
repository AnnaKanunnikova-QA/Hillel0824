﻿using NUnit.Framework;

namespace NUnitHomeworks
{
    internal class AsyncHomework
    {
        public async Task<string> GetStringAsync()
        {
            await Task.Delay(500);
            return "Hello, World!";
        }

        public async Task<int> GetNumberWithExceptionAsync()
        {
            await Task.Delay(1000);
            throw new InvalidOperationException("An error occurred while fetching the number.");
        }

        [Test]
        public async Task TestGetStringAsync()
        {
            // Arrange & Act
            var result = await GetStringAsync();

            // Assert
            Assert.That(result, Is.EqualTo("Hello, World!"));
        }

        [Test]
   
       public void TestGetNumberWithExceptionAsync()
        {
            // Arrange, Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await GetNumberWithExceptionAsync());
            Assert.That(ex.Message, Is.EqualTo("An error occurred while fetching the number."));
        }
    }
}