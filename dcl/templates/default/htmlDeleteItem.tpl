<!-- $Id: htmlDeleteItem.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<form class="styled" method="post" action="{$URL_MAIN_PHP}">
	<input type="hidden" name="menuAction" value="{$VAL_MENUACTION}" />
	<input type="hidden" name="{$VAL_IDFIELD}" value="{$VAL_ID}" />
{if $VAL_ID2FIELD != ""}
	<input type="hidden" name="{$VAL_ID2FIELD}" value="{$VAL_ID2}" />
{/if}
	<fieldset>
		<legend>{$TXT_TITLE|escape}</legend>
		<div class="confirm">{$VAL_WARNING|escape}</div>
		{if $TXT_DEACTIVATENOTE}<div class="help">{$TXT_DEACTIVATENOTE|escape}</div>{/if}
	</fieldset>
	<fieldset>
		<div class="submit">
			<input type="submit" value="{$smarty.const.STR_CMMN_YES}">
			<input type="button" onclick="javascript: history.back();" value="{$smarty.const.STR_CMMN_NO}">
		</div>
	</fieldset>
<form>
