# ferramentas-para-web-asp.net
pensado para estudos e usos diarios de iniciantes
-----------------------------------------------------
INSTRUNÇÕES
-----------------------------------------------------
1 - Insira esta classe na pasta AppCode de seu site (asp.net,asp.net core)

2 - Para fazer o uso da mesma Instancie a um novo objeto no behind da sua pagina (Backend - de sua pagina) exemplo:
WVL dll = new WVL(); //Chamando a classe a um novo objeto dando o nome de dll (o nome é de sua escolha)
string cpf = txtcpf.Text.ToString().Trim(); //criando uma variavel do tipo string que recebe todo texto da minha caixa sem espaços
Boolean valido = dll.Verifica_Cpf(cpf); // criando uma variavel Boolean (verdadeiro ou falso) chamada valido do qual digo que seu valor é o que a classe
ddl no verifica cpf (passando o cpf) me retornar.

3 - Caso for seu primeiro contato há algumas coisas importantes a serem colocadas em seu Backend
os usings!!!
![carbon (1)](https://user-images.githubusercontent.com/111321710/204152966-c84a7ffc-8e94-4f0b-a240-5b30c5df041e.png)


![carbon](https://user-images.githubusercontent.com/111321710/204152590-b0349c7b-b1cb-49bd-8487-a75bfcf4faf4.png)
