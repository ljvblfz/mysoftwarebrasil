<?php

class Zend_View_Helper_escapeFloat{


    public function setView(Zend_View_Interface $view)
    {
         $this -> view = $view;
         }


    public function escapeFloat($valor, $casasDecimais = 2, $arredondar = false, $separadorDecimal = null, $separadorMilhar = null)
    {
         $valor = Axs_Util_Float :: formataNumero($valor, $casasDecimais, $arredondar, $separadorDecimal, $separadorMilhar);
         return $valor;
         }
    }
