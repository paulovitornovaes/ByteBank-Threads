# Paralelismo no .NET

**Tela inicial**

![inicial](https://github.com/paulovitornovaes/ByteBank-Threads/blob/23de29024324a15d74ad159a92337e22fc4047a0/Assets/git/1.png)

**Processamento**

![loading](https://github.com/paulovitornovaes/ByteBank-Threads/blob/23de29024324a15d74ad159a92337e22fc4047a0/Assets/git/2.png)

**Processamento completo**

![complete](https://github.com/paulovitornovaes/ByteBank-Threads/blob/23de29024324a15d74ad159a92337e22fc4047a0/Assets/git/3.png)

**Processo cancelado**

![cancelled](https://github.com/paulovitornovaes/ByteBank-Threads/blob/23de29024324a15d74ad159a92337e22fc4047a0/Assets/git/4.png)


# Como executar

![download](https://github.com/paulovitornovaes/ByteBank-Threads/blob/223740052fbb67717fad8c179bd505f10f0c941b/Assets/git/download_1.png)

<p align="center">
  clique em executar o arquivo <b>Bytebank.exe</b>.
 </p>
 
<br>
<br>

# Objetivos

<p>O meu objetivo ao criar esse repositório foi de treinar meus conhecimentos com paralelismo em C# aplicando esses conceitos em uma aplicação que é separada em dois projetos, o core e o view, a View vai ser rodada pela thread principal, possibilitando assim que atualizemos o visual da aplicação para não parecer que ela está travada. </p>
<p>Dessa forma podemos visualizar a barra de progresso sendo atualizada em paralelo com o processamento de dados da aplicação.</p>
<p> Além disso existe a chamada assíncrona do botão <b>Fazer processamento</b> permitindo que a rotina ConsolidarContas seja feita de forma assíncrona. </p>
