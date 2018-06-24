# Descrição

## Objetivo
O projeto tem como objetivo a criação de um programa que leia valores de tensão de um osciloscópio Keysight InfiniiVision 1000 X-Series de um filtro conhecido, e calcule a resposta em frequência dele.

## Motivação
A motivação para esse conceito veio das aulas ministradas pelas cadeiras de circuitos elétricos e sinais e sistemas lineares do terceiro ano do curso de Telecomunicações, e pela aplicabilidade em projetos de engenharia.

# Tutorial

O tutorial realizado foi o deste [link](https://www.youtube.com/watch?v=Is1EHXFhEe4), o vídeo ensina como fazer uma calculadora em Windows Forms C#.
![calculadoraforms](https://user-images.githubusercontent.com/37377082/40875917-4abb9f6a-664f-11e8-8563-aab7e78dfc28.PNG)

O esboço inicial do projeto
![esboco](https://user-images.githubusercontent.com/37377082/40874940-a5b46da4-664d-11e8-99e4-ddc281e99070.PNG)

# Desenvolvimento do Projeto
O código foi feito em C# baseado em códigos já prontos, no exemplo que vem junto com o manual do osciloscópio e no código aplicativo THD do aluno Brasil.

A aparência gráfica do programa ficou da seguinte forma:


# Instrução de Compilação

Para compilar o programa, o usuário deve possuir o Visual Studio e criar um novo projeto. Depois, deve copiar e colar o código do Form1.cs no projeto criado. Para que o programa compile, é necessário que seja instalado o IO Libraries Suite que pode ser baixado neste [link](https://www.keysight.com/pt/pd-1985909/io-libraries-suite?nid=-33330.977662.00&cc=BR&lc=por&cmpid=zzfindiolib). 
Após instalado, deve ser adicionado como referência o VISA COM 5.9 Type Library, clicando-se com o botão direito no projeto criado > adicionar > referências > COM > VISA COM 5.9 Type Library. Por fim deve-se alterar a parte do código com *VisaComInstrument("USB0::0x0957::0x17A2::MY54450144::0::INSTR")* para o endereço do osciloscópio que for ser utilizado.

