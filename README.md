# Descrição

## Objetivo
O projeto tem como objetivo a criação de um programa que leia valores de tensão de um osciloscópio Keysight InfiniiVision 1000 X-Series de um filtro conhecido, e calcule e plote a resposta em frequência dele.

## Motivação
A motivação para esse conceito veio das aulas ministradas pelas cadeiras de circuitos elétricos e sinais e sistemas lineares do terceiro ano do curso de Telecomunicações, e pela aplicabilidade em projetos de engenharia.

## Fluxograma
O fluxograma do programa consiste nas seguintes etapas:
![fluxograma_filtro](https://user-images.githubusercontent.com/37377082/41868886-b7b75078-788d-11e8-83da-68686a4f595b.png)

## Diagrama de Classes
Foram estabelecidas duas classes, a classe VisaComInstrument já veio pronta com o código de exemplo do manual do osciloscópio. A classe Form1 no entanto, foi criada para realizar operações e interações com o usuário e realizar o plotagem do diagrama de bode
![capturar23](https://user-images.githubusercontent.com/37377082/41868974-ef283158-788d-11e8-9a20-e44a901f0259.PNG)


# Tutorial

O tutorial realizado foi o deste [link](https://www.youtube.com/watch?v=Is1EHXFhEe4), o vídeo ensina como fazer uma calculadora em Windows Forms C#.
![calculadoraforms](https://user-images.githubusercontent.com/37377082/40875917-4abb9f6a-664f-11e8-8563-aab7e78dfc28.PNG)

O esboço inicial do projeto
![esboco](https://user-images.githubusercontent.com/37377082/40874940-a5b46da4-664d-11e8-99e4-ddc281e99070.PNG)

# Desenvolvimento do Projeto
O código foi feito em C# baseado em códigos já prontos, no exemplo que vem junto com o manual do osciloscópio e no código aplicativo THD do aluno Brasil.

A aparência gráfica do programa ficou da seguinte forma:
![imagemprojeto](https://user-images.githubusercontent.com/37377082/41824250-b2ec18e4-77e3-11e8-87df-af61351fb691.PNG)

O código compila, no entanto, não pude verificar o funcionamento final do código no osciloscópio.


# Instrução de Compilação

Para compilar o programa, o usuário deve possuir o Visual Studio e criar um novo projeto. Depois, deve copiar e colar o código do Form1.cs no projeto criado. Para que o programa compile, é necessário que seja instalado o IO Libraries Suite que pode ser baixado neste [link](https://www.keysight.com/pt/pd-1985909/io-libraries-suite?nid=-33330.977662.00&cc=BR&lc=por&cmpid=zzfindiolib). 
Após instalado, deve ser adicionado como referência o VISA COM 5.9 Type Library, clicando-se com o botão direito no projeto criado > adicionar > referências > COM > VISA COM 5.9 Type Library. Por fim deve-se alterar a parte do código com *VisaComInstrument("USB0::0x0957::0x17A2::MY54450144::0::INSTR")* para o endereço do osciloscópio que for ser utilizado.

