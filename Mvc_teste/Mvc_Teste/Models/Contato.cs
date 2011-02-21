using System;
using Castle.ActiveRecord;
using Castle.Components.Validator;

/// <summary>
/// Summary description for Contato
/// </summary>
[ActiveRecord("Contatos")]
public class Contato : ActiveRecordValidationBase<Contato>
{
    private int id;
    private string nome;
    private string email;

    [PrimaryKey(PrimaryKeyType.Native, "Id")]
    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    [Property]
    [ValidateNonEmpty("Nome é requirido")]
    [ValidateLength(1, 255, "Nome deve ter no máximo 255 caracteres")]
    public string Nome
    {
      get { return nome; }
      set { nome = value; }
    }

    [Property]
    [ValidateNonEmpty("E-mail é requirido")]
    [ValidateLength(1, 255, "E-mail deve ter no máximo 255 caracteres")]
    [ValidateEmail("E-mail inválido")]
    public string Email
    {
      get { return email; }
      set { email = value; }
    }
}