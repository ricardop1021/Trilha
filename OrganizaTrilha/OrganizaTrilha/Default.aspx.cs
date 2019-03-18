using OrganizaTrilha.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrganizaTrilha
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int tempototal = 120, count = 0, tempotrilha = 480, tempocalculado = 0;
            List<Palestras> palestras = new List<Palestras>();
            string almoco = "horário de almoço", network = "Evento de network";
            TimeSpan temp = new TimeSpan(0, 0, 0);
            TimeSpan tp_final = new TimeSpan(9, 0, 0);
            TimeSpan tp_inicio = new TimeSpan(0, 0, 0);

            /*Preenchendo a lista*/
            InserirItens(palestras, almoco, network, temp);

            List<Palestras> palestrasOrdenadas = new List<Palestras>();
            /*metodo para definir a quatidade de trilhas existentes na lista*/
            ContarTrilhas(ref tempototal, ref count, palestras);
            int trilha = tempototal / tempotrilha;
            int flag = 0;


            for (int x = 0; x < trilha; x++)
            {
                palestrasOrdenadas.Add(new Palestras(0, "trilha" + (flag + 1), temp));
                /*aqui controlamos a quantidade de trilhas de acordo com  a quantidade de cadastros, 
                 * temos uma flag que é incrementada toda vez que termina de inserir uma trilha completa,
                 caso esta fçag for menor do que a quantidade de trilhas o loop continua*/
                if (flag < trilha)
                {
                    /*For para rodar até horario de almoço*/
                    for (int i = 0; i < palestras.Count; i++)
                    {

                        if ((tempocalculado <= tempotrilha - 1) && (palestras[i].Alocada == false))
                        {
                            if ((tempocalculado == 135) && (palestras[i].Tempo == 45) || (tempocalculado == 135) && (palestras[i].Tempo != 60) || (tempocalculado != 135))
                            {
                                /*metodo para encontrar o horario de almoço: se horario for igual a 12:00 ou 15 miutos antes, 
                                    * insere na lista o horario para almoço*/
                                if ((tempocalculado == 180) || (tempocalculado == 165))
                                {
                                    ExibirAlmoco(ref tempocalculado, palestras, almoco, palestrasOrdenadas, ref tp_final);
                                }

                                InserirPalestrasSeq(ref tempocalculado, palestras, almoco, network, ref tp_final, ref tp_inicio, palestrasOrdenadas, i);

                            }
                            if ((tempocalculado >= 450)&&(palestras[i].Tempo<=30))
                            {
                                for (int j = 0; j < palestras.Count; j++)
                                {
                                    if (palestras[i].Alocada == false)
                                    {

                                        InserirPalestrasSeq(ref tempocalculado, palestras, almoco, network, ref tp_final, ref tp_inicio, palestrasOrdenadas, i);
                                    }
                                }
                            }

                        }
                    }

                }
                tp_final = new TimeSpan(17, 0, 0);
                palestrasOrdenadas.Add(new Palestras(0, network, tp_final));
                tp_final = new TimeSpan(9, 0, 0);
                tempocalculado = 0;
                flag++;
            }



            /*apresentando na tela*/
            GVtrilhas.DataSource = palestrasOrdenadas;
            GVtrilhas.DataBind();





        }

        private static void InserirPalestrasSeq(ref int tempocalculado, List<Palestras> palestras, string almoco, string network, ref TimeSpan tp_final, ref TimeSpan tp_inicio, List<Palestras> palestrasOrdenadas, int i)
        {
            /*Esta condição se o nome da palestra for diferente de almoço ou workshop ele insere os itens na lista sequencialmente*/
            if ((palestras[i].Nome != almoco) && (palestras[i].Nome != network))
            {


                palestras[i].Hr_inicio = tp_final;
                palestrasOrdenadas.Add(palestras[i]);
                palestras[i].Alocada = true;
                tempocalculado += palestras[i].Tempo;
                if (palestras[i].Nome != almoco)
                {
                    tp_inicio = new TimeSpan(0, palestras[i].Tempo, 0);
                    tp_final += tp_inicio;
                }
            }
        }

        private static void InserirItens(List<Palestras> palestras, string almoco, string network, TimeSpan temp)
        {
            palestras.Add(new Palestras(60, "Escrevendo testes rápidos", temp));
            palestras.Add(new Palestras(45, "Uma visão sobre Python", temp));
            palestras.Add(new Palestras(30, "Angular", temp));
            palestras.Add(new Palestras(45, "Otimizando aplicações com o NodeJS", temp));
            palestras.Add(new Palestras(45, "Erros comuns no desenvolvimento de software", temp));
            palestras.Add(new Palestras(60, "Rails para Desenvolvedores Python", temp));
            palestras.Add(new Palestras(60, "ASP.net MVC", temp));
            palestras.Add(new Palestras(45, "TDD na prática", temp));
            palestras.Add(new Palestras(30, "Woah", temp));
            palestras.Add(new Palestras(30, "Sente e escreva", temp));
            palestras.Add(new Palestras(45, "Pair Programming vs Noise", temp));
            palestras.Add(new Palestras(60, "Mobilidade em desenvolvimento", temp));
            palestras.Add(new Palestras(60, "Ruby on Rails: Por que devemos migrar para ele?", temp));
            palestras.Add(new Palestras(45, "Otimizando aplicações .NET", temp));
            palestras.Add(new Palestras(30, "Java e os novos paradigmas de programação", temp));
            palestras.Add(new Palestras(30, "Rubi vs. Clojure para Back-End", temp));
            palestras.Add(new Palestras(60, "Scrum para leigos", temp));
            palestras.Add(new Palestras(30, "Um mundo sem stackoverflow", temp));
            palestras.Add(new Palestras(30, "UX", temp));
            palestras.Add(new Palestras(0, network, temp));
            palestras.Add(new Palestras(60, almoco, temp));
        }

        private static void ContarTrilhas(ref int tempototal, ref int count, List<Palestras> palestras)
        {
            for (int i = 0; i < palestras.Count; i++)
            {
                tempototal += palestras[i].Tempo;
                count++;
            }
        }

        private static void ExibirAlmoco(ref int tempocalculado, List<Palestras> palestras, string almoco, List<Palestras> palestrasOrdenadas, ref TimeSpan tp_final)
        {
            for (int j = 0; j < palestras.Count; j++)
            {
                if (palestras[j].Nome == almoco)
                {
                    palestras[j].Hr_inicio = new TimeSpan(12, 0, 0);
                    palestrasOrdenadas.Add(palestras[j]);
                    palestras[j].Alocada = true;
                    tempocalculado = 240;
                    tp_final = new TimeSpan(12, 0, 0);
                    //Console.WriteLine("horario de inicio: " + tp_final + ", tempo de duração: " + 60 + ", Horario de almoço");
                    tp_final = new TimeSpan(13, 0, 0);
                    break;
                }
            }
        }
    }
}