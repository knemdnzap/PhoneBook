using System;
using PhoneBook;
using Test;
using Xunit;

namespace PhoneBook.Tests;

public class Test
{
    const int success = 1;
    const int fail = 0;
    const int Available = 3;

    #region AddContactTest
        // Se prueba añadir contacto
        [Theory]
        [InlineData("Nicolas", "300779", "300779")]
        public void AddContact_Test(string name, string phone, string cellPhone)
        {
            int result = new TestBook().AddContact_Test(name, phone, cellPhone);
            Assert.Equal(result, success);
        }

        // Prueba de añadir estando agenda llena
        [Theory]
        [InlineData("Liliana", "300779", "300779")]
        public void TryAddFullPhoneBook(string name, string phone, string cellPhone)
        {
            int result = new TestBook().FullAddContact_Test(name, phone, cellPhone);
            Assert.Equal(result, fail);
        }

        // Pruba de validación de contacto existente
        [Theory]
        [InlineData("Nicolas", "300779", "300779")]
        public void TestAddSameContact(string name, string phone, string cellPhone)
        {
            int result = new TestBook().TryToAddSameContact(name, phone, cellPhone);
            Assert.Equal(result, fail);
        }
    #endregion

    #region ListContactTest
        // Prueba de si se muestran los datos de manera correcta
        [Fact]
        public void ListContact_Test()
        {
            int result = new TestBook().ListContact_Test();
            Assert.Equal(result, success);
        }
    #endregion

    #region ExistContactTest
        // Prueba que muestra si se hace correctamente la validación de que existe el contacto
        [Theory]
        [InlineData("Nicolas")]
        public void ExistContact_Test(string name)
        {
            int result = new TestBook().ExistContact_Test(name);
            Assert.Equal(result, success);
        }

        // // Prueba que muestra si se hace correctamente la validación de que no existe el contacto
        [Theory]
        [InlineData("Nicolas")]
        public void NotExistContact_Test(string name)
        {
            int result = new TestBook().NotExistContact_Test(name);
            Assert.Equal(result, success);
        }
    #endregion

    #region FindContactTest
        // Prueba que valida si busca de manera correcta el contacto
        [Theory]
        [InlineData("Nicolas")]
        public void FindContact_Test(string name)
        {
            Contact contact = new TestBook().FindContact_Test(name);
            Assert.NotNull(contact);
        }

        // Prueba que indica que no encontro el contacto
        [Theory]
        [InlineData("Nicolas")]
        public void NotFindContact_Test(string name)
        {
            Contact contact = new TestBook().NotFindContact_Test(name);
            Assert.Null(contact);
        }
    #endregion

    #region DeleteContactTest
        // Prueba que elimina un contacto
        [Theory]
        [InlineData("Nicolas")]
        public void DeleteContact_Test(string name)
        {
            int result = new TestBook().DeleteContact_Test(name);
            Assert.Equal(result, success);
        }

        // Prueba que elimina un contacto que no existe
        [Theory]
        [InlineData("Fabio")]
        public void DeleteContactNotExist_Test(string name)
        {
            int result = new TestBook().DeleteContactNotExist_Test(name);
            Assert.Equal(result, fail);
        }
    #endregion

    #region FullContactTest
        // Validación de verificación de agenda llena
        [Fact]
        public void FullContact_Test()
        {
            bool result = new TestBook().FullContact_Test();
            Assert.Equal<bool>(result, true);
        }

        // Validación de verificación de agenda no esta llena
        [Fact]
        public void NotFullContact_Test()
        {
            bool result = new TestBook().NotFullContact_Test();
            Assert.Equal<bool>(result, false);
        }
    #endregion

    #region AvailableContactTest
        // Prueba de espacios disponibles para añadir contacto
        [Fact]
        public void AvailableContact_Test()
        {
            int result = new TestBook().AvailableContact_Test();
            Assert.Equal(result, Available);
        }

        // Prueba de espacios no disponibles para añadir contacto
        [Fact]
        public void NotAvailableContact_Test()
        {
            int result = new TestBook().NotAvailableContact_Test();
            Assert.Equal(result, fail);
        }
    #endregion
}