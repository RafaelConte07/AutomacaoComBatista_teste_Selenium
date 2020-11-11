// Bibliotecas
using NUnit.Framework; // motor d NUnit
using OpenQA.Selenium; // motor do Selenium WebDriver
using OpenQA.Selenium.Chrome; // driver do chrome
using System.Threading;


// namespace

namespace TestLinkTest
{

    //classes 
    public class Usuario
    {
        // Atributo
        string urlBase; // endereço do site alvo
        IWebDriver driver; // objeto do selenium webdrive

        //metodo
        [SetUp] // tag do NUnit para executar antes do teste
        public void Iniciar()
        {
            //iniciar
            urlBase = "https://automacaocombatista.herokuapp.com/";
            driver = new ChromeDriver(); // intancie o selenium com o chrome
        }

        [TearDown]// tag do NUNIt para executar apos os testes
        public void Finalizar()
        {
            //encerar   
            driver.Quit(); // desliga o objeto selenium
        }

        [Test]
        public void loginPositivo()
        {

            //Executar o Teste
            driver.Navigate().GoToUrl(urlBase + "treinamento/home"); // abrir a pagina web


            var btnWeb = driver.FindElement(By.LinkText("Formulário"));
            btnWeb.Click();

            var btnUsuario = driver.FindElement(By.CssSelector(".active li:nth-child(1) > a"));
            btnUsuario.Click();

            driver.FindElement(By.Id("user_name")).SendKeys("Fingolfin");
            driver.FindElement(By.Id("user_lastname")).SendKeys("Noldor");
            driver.FindElement(By.Id("user_email")).SendKeys("fingolfin.silmarillion@bol.com.br");
            driver.FindElement(By.Id("user_address")).SendKeys("Valinor");
            driver.FindElement(By.Id("user_university")).SendKeys("Impacta");
            driver.FindElement(By.Id("user_profile")).SendKeys("Qa");
            driver.FindElement(By.Id("user_gender")).SendKeys("Masculino");
            driver.FindElement(By.Id("user_age")).SendKeys("3578 anos");

            var btnCriarUsuario = driver.FindElement(By.CssSelector(".actions"));
            btnCriarUsuario.Click();
            Thread.Sleep(2000);

            //selecionar o frame / div onde faremos a validaçãodo usuário perfil
            // driver.Switch().Frame("title");

            //valida se está logado com usuário e perfil correto
            // Assert.AreEqual("Treinamento", driver.FindElement(By.LinkText("Treinamento")).ToString());

            //clicar no botão sair
            driver.FindElement(By.CssSelector(".waves-light")).Click();

            Thread.Sleep(3000);

            //validar se o usuário saiu e volto a pagina de login
            //StringAssert.Contains("Please", driver.FindElement(By.CssSelector("")));

        }
    }
}
