<?php
/**
 * Classe para tratar os itens
 * 
 * @name Axs_Util_Item
 * @author Нtalo Pereira 1/10/2008 09:44:12 
 * @package Axs_Util
 * @version $Id: Item.php,v 1.1 2009/03/25 18:43:16 delano Exp $  
 */
class Axs_Util_Item {
    /**
     * Funзгo para fazer a limpeza dos itens vazios ou desnecessбrios.
     * 
     * @name limpaItem 
     * @param array $data
     * @access public
     * @return array $data
     */
	public static function limpaItem(array $data) {
        //limpa os itens vazios
        foreach($data as $indice => $dados){
            foreach($dados as $campo => $valor){
                if(empty($valor) || $valor == '0,00'){
                    unset($data[$indice][$campo]);
                }                
            }
            if($data[$indice] == array()){
                unset($data[$indice]);
            }
        }
        
        return $data;
	}

} 

?>