<!-- $Id: htmlAdminMain.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<table width="100%" class="dcl_results">
	<caption>{$TXT_SETUPTITLE}</caption>
	<thead><tr><th>Option</th><th>Description</th></tr></thead>
	<tbody>
{foreach item=option key=menuAction from=$VAL_OPTIONS}
	{cycle values="odd,even" assign="rowClass"}
		<tr class="{$rowClass}"><td valign="top" nowrap="nowrap"><a href="{$URL_MAIN_PHP}?menuAction={$menuAction}">{$option.action}</a></td>
			<td>{$option.description}{if $option.note != ""} <span class="error">{$option.note}</span>{/if}</td>
		</tr>
{/foreach}
	</tbody>
</table>