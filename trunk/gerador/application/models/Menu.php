<?php
/**
 * Modelo da tabela menu
 *
 * @name Sistemamenu
 * @author Alexis moura
 * @package sistema_models
 * @version $Id$
 */
class Menu extends Sabv_Db_Table
{

    /**
     * Nome da tabela do Banco de Dados
     *
     * @name $_name
     * @access protected
     * @var string
     */
    protected $_name = 'menu';

    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                     	             'id_pai' => array('Int','allowEmpty'=>true),
                     	             'num_ordem' => array('Int','allowEmpty'=>true),
                     	             'desc_link' => array('allowEmpty'=>true),
                     	             'desc_comentario' => array('allowEmpty'=>true),
                     	             'nome_menu' => array('allowEmpty'=>true),
                     	             'sgl_sist' => array('allowEmpty'=>true),
                     	             'imagem' => array('allowEmpty'=>true),
                     	             'TOTAL' => array('allowEmpty'=>true),
                   	                 'id' => array( 'Int','notEmpty','presence'=>'required')
                                  );

    /**
     * Array de filtros do modelo
     *
     * @name $_filters
     * @access protected
     * @var array
     */
    protected $_filters = array(
                                  'id_pai' => array('EmptyStringToNull'),
                                  'num_ordem' => array('EmptyStringToNull'),
                                  'desc_link' => array('EmptyStringToNull'),
                                  'desc_comentario' => array('EmptyStringToNull'),
                                  'nome_menu' => array('EmptyStringToNull'),
                                  'sgl_sist' => array('EmptyStringToNull'),
                                  'imagem' => array('EmptyStringToNull'),
                                  'TOTAL' => array('EmptyStringToNull'),
                                  'id' => array('EmptyStringToNull')
                                );

    /**
     * Método para validações especificas do modelo utilizado para inserção.
     *
     * @name validaInsert
     * @param array $data
     * @access public
     * @return boolean
     */
    public function validaInsert($dados)
    {
        // Verifica se os campos são coerentes com o modelo.
        if(!$this->isValid($dados)) {
        	Rps_Db_Table::setErrosStatic($this->getErros());
        	return false;
        } else {
            return true;
        }
    }

    /**
     * Método para validações especificas do modelo utilizado para atualização.
     *
     * @name validaUpdate
     * @param array $dados
     * @access public
     * @return boolean
     */
    public function validaUpdate($dados)
    {
        // Verifica se os campos são coerentes com o modelo.
        if(!$this->isValid($dados)) {
        	Rps_Db_Table::setErrosStatic($this->getErros());
        	return false;
        } else {
            return true;
        }
    }

    /**
     * Método para validações especificas do modelo utilizado para exclusão.
     *
     * @name validaDelete
     * @param array $dados
     * @access public
     * @return boolean
     */
    public function validaDelete($dados)
    {
        // Verifica se os campos são coerentes com o modelo.
        if(!$this->isValid($dados)) {
        	Rps_Db_Table::setErrosStatic($this->getErros());
        	return false;
        } else {
            return true;
        }
    }


}

