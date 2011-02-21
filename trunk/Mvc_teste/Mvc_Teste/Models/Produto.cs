using System;
using Castle.ActiveRecord;
using Castle.Components.Validator;

/// <summary>
/// Summary description for Produto
/// </summary>
[ActiveRecord("Produto")]
public class Produto : ActiveRecordValidationBase<Produto>
{
    private int ProdutoId;
    private int Qtd;
    private string Nome;

    [PrimaryKey(PrimaryKeyType.Native, "ProdutoId")]
    public int produtoId
    {
        get { return produtoId; }
        set { produtoId = value; }
    }

    [Property]
    [ValidateNonEmpty("Nome é requirido")]
    [ValidateLength(1, 255, "Nome deve ter no máximo 255 caracteres")]
    public string nome
    {
        get { return nome; }
        set { nome = value; }
    }

    [Property]
    [ValidateNonEmpty("Nome é requirido")]
    [ValidateLength(1, 11, "Máximo ultrapassado")]
    public int qtd
    {
        get { return qtd; }
        set { qtd = value; }
    }
}