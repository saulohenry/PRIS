using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.DAL;
using Model;
using System;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace APITest
{
    [TestClass]
    public class ImovelTest
    {
        [TestMethod]
        public void TestImovelControllerIndex()
        {
            List<Model.Imovel> imoveis = new List<Model.Imovel>();

            imoveis.Add(new Model.Imovel() { ID = 1, Endereco = "", numero = 100, Data = DateTime.Now });

            var mockRepository = new Mock<Repository<Model.Imovel>>();
            mockRepository.Setup(x => x.Get()).Returns(imoveis);

            var contoller = new ImovelController(mockRepository.Object);

            IActionResult action = contoller.Index();

            Assert.IsNotInstanceOfType(action, typeof(OkResult));
        }

        [TestMethod]
        public void TestImovelControllerDetais()
        {
            var mockRepository = new Mock<Repository<Model.Imovel>>();
            mockRepository.Setup(x => x.GetByID(1)).Returns(new Model.Imovel { ID = 1, Endereco = "", numero = 100, Data = DateTime.Now });

            var contoller = new ImovelController(mockRepository.Object);

            ActionResult<Model.Imovel> action = contoller.Details(1);

            Assert.IsNotInstanceOfType(action, typeof(OkResult));
        }

        [TestMethod]
        public void TestImovelControllerCreate()
        {
            Model.Imovel imovel = new Model.Imovel() { ID = 1, Endereco = "", numero = 100, Data = DateTime.Now };

            var mockRepository = new Mock<Repository<Model.Imovel>>();
            mockRepository.Setup(x => x.Insert(imovel)).Returns(new Model.Imovel { ID = 1, Endereco = "", numero = 100, Data = DateTime.Now });

            var contoller = new ImovelController(mockRepository.Object);

            ActionResult<Model.Imovel> action = contoller.Create(imovel);

            Assert.IsNotInstanceOfType(action, typeof(OkResult));
        }

        [TestMethod]
        public void TestImovelControllerEdit()
        {
            Model.Imovel imovel = new Model.Imovel() { ID = 1, Endereco = "", numero = 100, Data = DateTime.Now };

            var mockRepository = new Mock<Repository<Model.Imovel>>();
            mockRepository.Setup(x => x.Update(imovel)).Returns(new Model.Imovel { ID = 1, Endereco = "", numero = 100, Data = DateTime.Now });

            var contoller = new ImovelController(mockRepository.Object);

            ActionResult action = contoller.Edit(imovel.ID, imovel);

            Assert.IsNotInstanceOfType(action, typeof(OkResult));
        }

        [TestMethod]
        public void TestImovelControllerDelete()
        {
            Model.Imovel imovel = new Model.Imovel() { ID = 1, Endereco = "", numero = 100, Data = DateTime.Now };

            var mockRepository = new Mock<Repository<Imovel>>();
            mockRepository.Setup(x => x.Delete(imovel));

            var contoller = new ImovelController(mockRepository.Object);

            ActionResult action = contoller.Delete(imovel.ID);

            Assert.IsNotInstanceOfType(action, typeof(OkResult));
        }

    }
}
