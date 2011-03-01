<?php
include("helpCommon.php");

helpHeader();
?>
<H3>Recherche des appels</H3>
L'�cran de recherche des appels est divis� en deux parties. La premi�re partie sert � la recherche d'un appel sp�cifique par son num�ro et (optionnellement) sa s�quence.  La seconde permet de s�lectionner une ou plusieurs options pour filtrer la requ�te.
<BR>
<BR>
<H4>Recherche par No d'Appel/Seq</H4>
Si vous connaissez le num�ro d'appel, vous pouvez l'entrer en haut de l'�cran pour afficher le d�tail de l'appel. Vous n'avez pas � entrer un num�ro de s�quence pour l'affichage.  DCL affichera le d�tail de l'appel seulement si une s�quence existe pour ce num�ro d'appel. Autrement, si plusieurs s�quences sont trouv�es, DCL affichera une liste de r�sultat et vous permettra de les parcourir comme si vous aviez demand� une recherche.
<BR>
<BR>
<H4>Recherche Par Param�tres</H4>
DCL vous permet �galement d'effectuer une recherche en sp�cifiant un ou plusieurs filtres pour faire r�cup�rer les appels ordonn�es. Cet interface est assez puissante, m�me si elle n'est pas termin�e.  Notez que pour les param�tres de recherche qui utilisent des zones de listes, vous pouvez s�lectionner plusieurs valeurs pour la recherche (i.e., si un statut est ouvert, non assign� the status ou remis � plus tard.)
<H5>Personnel</H5>
Les cases � cocher vous permettent de rechercher diff�rents champs concernant les appels � trouver et qui a fait quoi. Il y a:
<UL>
<LI><B>Responsable</B>&nbsp;-&nbsp;Cochez cette case pour r�duire la liste de tous les appels � ceux dont les personnees choisies sont responsables.</LI>
<LI><B>Ouvert Par</B>&nbsp;-&nbsp;Selectionnez ceci pour avoir les appels ouvert par les personnes choisies.</LI>
<LI><B>Ferm� Par</B>&nbsp;-&nbsp;Cette option vous permet de rechercher les appels ferm�s par les personnes choisies.</LI>
</UL>
<H5>Produit, Priorit�, S�v�rit�, Clients, Statuts</H5>
Si vous voulez r�duire votre recherche � un de ces champs, s�lectionnez les �l�ments appropri�s.
<H5>Dates</H5>
Vous pouvez r�duire les p�riodes de certains champs entre des dates.  S�lectionner les cases � cocher des champs appropri�s et ajustez les dates From:(Depuis) et To: (a) comme il est n�cessaire. Les petits icones calendriers � la droite des champs date vont faire apparaitre un petit calendrier Javascript si vous pr�f�rez s�lectionner vos date de mani�re graphique. 
<H5>R�sum�, Notes, Description</H5>
Selectionn�z n'importe quelle combinaison des trois champs et tapez votre texte de recherche dans la zone de saisie en dessous. Notez que la recherche sur ces champs se fait sur la &quot;phrase&quot enti�re;.  Cela signifie que pour qu'un champ corresponde, il faut qu'il contienne la phrase sp�cifi�e <EM>exactement telle qu'elle est tap�e</EM>.  Avec certaines bases de donn�es, (comme l'install par d�faut de  PostgreSQL), vous devez m�me tenir compte des minuscules/majuscules.  D'autres (i.e., Microsoft SQL Server) sont g�n�ralement configur�s pour faire des recherche sans tenir compte des majuscules/minuscules.
<?php
helpFooter();
?>
