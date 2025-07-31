using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook;
using System;
using System.Collections.Generic;

namespace Phonebook.Tests
{
    [TestClass]
    public class PhoneBook
    {
        [TestInitialize]
        public void Setup()
        {
            phoneBook = new PhoneBook();
        }
    }
}
