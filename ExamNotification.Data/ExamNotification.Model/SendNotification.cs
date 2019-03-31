using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using ExamNotification.Controller.Controladoras;
using ExamNotification.Data;


namespace ExamNotification.Model
{
    public class SendNotification
    {
        public void Send()
        {

            ControlEvento _controladoraEvento = new ControlEvento();
            ControlAluno _controladoraAluno = new ControlAluno();
            ControlCurso _controladorCurso = new ControlCurso();


            foreach(var key in _controladoraEvento.SelecionarTodos())
            {
                if(key.Data_aviso <= key.Data_final)
                {
                    List<Alunos> nomeAluno = key.Disciplinas.Curso.Alunos.ToList();
                    foreach(var aluno in nomeAluno)
                    {
                        string alunoNome = aluno.Nome;
                        string cursoNome = key.Disciplinas.Curso.Nome;
                        string disciplinaNome = key.Disciplinas.Nome;
                        string Assunto = key.Nome;
                        string mensagem = "Olá, "+alunoNome+" este é um e-mail refêrente ao seu curso <b>"+ cursoNome + "</b> com o objetivo de notificá-lo sobre a disciplina <b:>"+ disciplinaNome+ "<b><br>" +
                            key.Descricao;

                    //Implementação do envio de e-mail
                        MailMessage objEmail = new MailMessage();
                        objEmail.From = new MailAddress("email do remetente");
                        MailAddress oEmail = new MailAddress(aluno.Email, aluno.Nome);
                        objEmail.To.Add(oEmail);
                        objEmail.Priority = MailPriority.Normal;
                        objEmail.IsBodyHtml = true;
                        objEmail.Subject = Assunto;
                        objEmail.Body = mensagem;
                        objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                        objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                        SmtpClient objSmtp = new SmtpClient();
                        objSmtp.Host = "smtp.gmail.com";
                        objSmtp.EnableSsl = true;
                        objSmtp.Port = 587;
                        objSmtp.Credentials = new NetworkCredential("email do remetente", "senha do email");
                        objSmtp.Send(objEmail);

                    }

                }
            }
        }
    }
}
