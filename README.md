Cadastro de motos e entregadores.

Acesso ao MotorcycleRegister GET/POST/DELETE/PUT só podera ser feito com acesso Adm: Entre com login e senha de administrador, em seguida pegue o token gerado e adicione ao campo Authorize.
# Para validar o token digite Bearer adicione o token, com isso,  terá as permissoes necessarias.
* Login: admmottu e Senha admmottu
# Exemplo: Bearer dfhfhfhfjahfjkdsahfjçskadhgkjçashgfkaçsaçkh.awfjoweafaedjfadhjgoiahfgodahg => respeite o espaço após digitar Bearer

Funcionamento do sistema
 * Cadastre as motos: Utilize o endpoint Post/api/v1/motorcycleRegister
 * Para os entregadores: Siga a documentação abaixo
1 Os planos para escolher podem ser vistos na tela utilizando ChoosePlans endpoint com final  /plansRent
2 Verifique os planos que podem ser escolhidos e quando for fazer uma locação escolhe o plano de 1 a 5. Atenção coloque o numero do plano
3 Após cadastre o entregador com um dos planos e, seus documentos, escolha a moto, e coloque as datas inicial e final. Utilize o endpoint /api/v1/rentedMotorcycle
4 As informaçãoes estarão na collection de informaçãoes de locação com o acesso ao endpoint /api/v1/rentedMotorcycle/all
5 Após poderá verificar com os endponts de Get/api/v1/motorcycleRegister/all e Get/api/v1/rentedMotorcycle/rentByCNH, as informações que se encontram em cada collection.
6 Com o endpoint /api/v1/rentedMotorcycle/closeRent, após a entrega, será verificado se houve multas para a locação.
