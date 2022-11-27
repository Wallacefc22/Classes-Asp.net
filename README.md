# ferramentas-para-web-asp.net
pensado para estudos e usos diarios !
-----------------------------------------------------
INSTRUNÇÕES
-----------------------------------------------------
1 - Insira esta classe na pasta AppCode de seu site (asp.net,asp.net core)

2 - Para fazer o uso da mesma Instancie a um novo objeto no behind da sua pagina (Backend - de sua pagina) exemplo:
WVL dll = new WVL(); //Chamando a classe a um novo objeto dando o nome de dll (o nome é de sua escolha)

string cpf = txtcpf.Text.ToString().Trim(); //criando uma variavel do tipo string que recebe todo texto da minha caixa sem espaços

Boolean valido = dll.Verifica_Cpf(cpf); // criando uma variavel Boolean (verdadeiro ou falso) chamada valido do qual digo que seu valor é o que a classe
ddl no verifica cpf (passando o cpf) me retornar.

3 - Faça suas modificações e explore o arquivo entenda como ele funciona leia linha por linha isso te ajudarará a se desenvolver
![carbon (2)](https://user-images.githubusercontent.com/111321710/204153143-3c2edab0-d5dd-47b2-9707-2c74a17e153f.png)
