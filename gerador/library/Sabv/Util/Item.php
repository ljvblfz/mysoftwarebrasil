<?php

class Sabv_Util_Item{

     public static function limpaItem(array $data, $chaves = array(), $objeto = null){
         foreach($data as $indice => $dados){
             $valorChaves = '';
             foreach($dados as $campo => $valor){
                 if(empty($valor) || $valor == '0,00'){
                     unset($data[$indice][$campo]);
                     }

                 foreach($chaves as $registro){
                     if($campo == $registro && !empty($valor) && $valor != '0,00'){
                         $valorChaves = $valorChaves . '-' . $registro . '-' . $valor;
                         $valores[$indice] = $valorChaves;
                         }
                     }
                 }

             if($data[$indice] == array()){
                 unset($data[$indice]);
                 }
             }

         if(isset($valores)){
             $count = array_count_values($valores);

             foreach($count as $key => $value){
                 if($value > 1){
                     $mensagemErro = "O item ";

                     $explodeKey = explode('-', $key);
                     unset($explodeKey[0]);

                     $countChaves = count($chaves);
                     $totalChaves = $countChaves;

                     if(count($explodeKey) / 2 == $countChaves){
                         foreach($chaves as $indiceChave => $valorChave){
                             $i = $indiceChave + 1;

                             if($countChaves == 1){
                                 $mensagemErro = $mensagemErro . "{$objeto->descricaoCampos[$valorChave]} com o valor {$explodeKey[$i*2]} está duplicado.";
                                 }else{ // Se há mais de uma chave
                                 $mensagemErro = $mensagemErro . "{$objeto->descricaoCampos[$valorChave]} com o valor {$explodeKey[$i*2]}";

                                 if($totalChaves > 1){
                                     $mensagemErro = $mensagemErro . " e o item ";
                                     $totalChaves--;
                                     }else{ // Se não houver mais chaves finaliza a mensagem
                                     $mensagemErro = $mensagemErro . " estão duplicados.";
                                     }
                                 }
                             }

                         $erros['ERROS_ITEM'] = array($mensagemErro);
                         $objeto -> setErros($erros);
                         }
                     }
                 }
             }

         if(isset($erros)){
             return false;
             }else{
             return $data;
             }
         }
    }
