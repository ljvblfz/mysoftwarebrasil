<!-- $Id: htmlFaqquestionsDetail.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<center>
<table border="0" cellspacing="0" style="width: 80%;">
	<tr><th class="detailTitle"><a href="{$URL_MAIN_PHP}?menuAction=boFaq.view&faqid={$VAL_FAQID}">{$VAL_FAQNAME|escape}</a> : <a href="{$URL_MAIN_PHP}?menuAction=boFaqtopics.view&topicid={$VAL_TOPICID}">{$VAL_TOPICNAME|escape}</a></th>
		<th class="detailLinks">{if $PERM_ADDANSWER}<a class="adark" href="{$URL_MENULINK}?menuAction=boFaqanswers.add&questionid={$VAL_QUESTIONID}">{$smarty.const.STR_CMMN_NEW}</a>{else}&nbsp;{/if}</th>
	</tr>
	<tr><td colspan="2">{$VAL_QUESTIONTEXT|escape|nl2br}</td></tr>
{section name=answer loop=$VAL_ANSWERS}
	{if $smarty.section.answer.first}
		<tr><td colspan="2"><ol>
	{/if}
		<li>{$VAL_ANSWERS[answer].answertext|escape|nl2br}{if $PERM_MODIFY || $PERM_DELETE}&nbsp;[&nbsp;
		{if $PERM_MODIFY}<a href="{$URL_MAIN_PHP}?menuAction=boFaqanswers.modify&answerid={$VAL_ANSWERS[answer].answerid}">{$smarty.const.STR_CMMN_EDIT}</a>{/if}
		{if $PERM_DELETE}{if $PERM_MODIFY}&nbsp;|&nbsp;{/if}<a href="{$URL_MAIN_PHP}?menuAction=boFaqanswers.delete&answerid={$VAL_ANSWERS[answer].answerid}">{$smarty.const.STR_CMMN_DELETE}</a>{/if}
		&nbsp;]
		{/if}</li>
	{if $smarty.section.answer.last}
		</ol></td></tr>
	{/if}
{sectionelse}
	<tr><td colspan="2">{$smarty.const.STR_FAQ_NOANSWERS}</td></tr>
{/section}
</table>
</center>