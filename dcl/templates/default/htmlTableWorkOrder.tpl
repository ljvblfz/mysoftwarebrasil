<!-- $Id: htmlTableWorkOrder.tpl 74 2007-03-04 20:00:42Z mdean $ -->
<script language="JavaScript">
{literal}
function toggle(btnSender)
{
	var bChk = btnSender.checked;
	var bOK = false;
	var e=btnSender.form.elements;
	for (var i=0;i<e.length;i++)
	{
		if (!bOK && e[i] == btnSender)
			bOK = true;
		else if (bOK && (e[i].type != "checkbox" || e[i].name == "group_check"))
			return;
		else if (bOK && e[i].type == "checkbox")
			e[i].checked = bChk;
	}
}
function showAccounts(iWOID, iSeq)
{
	var sURL = 'main.php?menuAction=htmlWindowList.FrameRender&what=dcl_wo_account.wo_id&wo_id=' + iWOID + '&seq=' + iSeq;
	var newWin = window.open(sURL, '_dcl_selector_', 'width=500,height=255');
}

function submitBatch()
{
	var f = document.forms.searchAction;
	var sAction = f.elements.menuAction.value;

	if (sAction == 'boWorkorders.batchdetail' || sAction == 'boTimecards.batchadd' || sAction == 'boWorkorders.batchassign' || sAction == 'htmlProjectmap.move' || sAction == 'htmlProjectmap.batchmove')
	{
		var bHasCheck = false;
		for (var i = 0; i < f.elements.length && !bHasCheck; i++)
		{
			bHasCheck = (f.elements[i].type == "checkbox" && f.elements[i].name != "group_check" && f.elements[i].checked);
		}

		if (!bHasCheck)
		{
			alert('You must select one or more items!');
			return;
		}
	}
	f.submit();
}

function jumpToPage(iPage)
{
}
{/literal}
</script>
<div class="dcl_filter">
	<form name="pager" method="post" action="{$URL_MAIN_PHP}">
		{$VAL_VIEWSETTINGS}
		<input type="hidden" name="menuAction" value="{$VAL_FILTERMENUACTION}" />
		<input type="hidden" name="startrow" value="{$VAL_FILTERSTARTROW}" />
		<input type="hidden" name="numrows" value="{$VAL_FILTERNUMROWS}" />
		<input type="hidden" name="jumptopage" value="{$VAL_PAGE}" />
		<span><label for="filterStatus">{$smarty.const.STR_WO_STATUS}:</label> {dcl_select_status default=$VAL_FILTERSTATUS name=filterStatus allowHideOrOnlyClosed=Y}</span>
		<span><label for="filterType">{$smarty.const.STR_WO_TYPE}:</label> {dcl_select_wo_type  default=$VAL_FILTERTYPE name=filterType}</span>
		{if !$VAL_ISPUBLIC}<span><label for="filterReportto">{$smarty.const.STR_WO_RESPONSIBLE}:</label> {dcl_select_personnel  default=$VAL_FILTERREPORTTO name=filterReportto}</span>{/if}
		<span><label for="filterProduct">{$smarty.const.STR_WO_PRODUCT}:</label> {dcl_select_product  default=$VAL_FILTERPRODUCT name=filterProduct}</span>
		<input type="submit" name="filter" value="Filter">
		{if $VAL_PAGES > 1}
			{strip}<div><ul>
			{if $VAL_PAGE > 1}
			<li class="first"><a href="#" onclick="forms.pager.jumptopage.value={$VAL_PAGE-1};forms.pager.submit();">&lt;&lt;</a></li>
			{/if}
			{if $VAL_PAGE > 5}{assign var=startpage value=$VAL_PAGE-5}{else}{assign var=startpage value=1}{/if}
			{if $VAL_PAGE < ($VAL_PAGES-6)}{assign var=endpage value=$VAL_PAGE+6}{else}{assign var=endpage value=$VAL_PAGES+1}{/if}
			{section name=iPage start=$startpage loop=$endpage step=1}
			<li{if $smarty.section.iPage.first && $VAL_PAGE < 2} class="first"{/if}>{if $smarty.section.iPage.index == $VAL_PAGE}<strong>{$VAL_PAGE}</strong>{else}<a href="#" onclick="forms.pager.jumptopage.value={$smarty.section.iPage.index};forms.pager.submit();">{$smarty.section.iPage.index}</a>{/if}</li>
			{/section}
			{if $VAL_PAGE < $VAL_PAGES}
			<li><a href="#" onclick="forms.pager.jumptopage.value={$VAL_PAGE+1};forms.pager.submit();">&gt;&gt;</a></li>
			{/if}
			</ul></div>{/strip}
		{/if}
	</form>
</div>
{assign var=groupcount value=$groups|@count}
{assign var=colcount value=$columns|@count}
{if $rownum}{assign var=colcount value=$colcount+1}{/if}
{if $checks}{assign var=colcount value=$colcount+1}
	<form name="searchAction" method="post" action="{$URL_MAIN_PHP}"><input type="hidden" name="menuAction" value="" />{$VAL_VIEWSETTINGS}
{/if}
<table class="dcl_results{if $inline} inline{/if}">
{if $caption ne ""}<caption>{$caption|escape}</caption>{/if}
{strip}
{section loop=$columns name=col}
	{if $smarty.section.col.first}<thead>
	{if $toolbar}
	<tr class="toolbar"><th colspan="{$colcount}">
	{section loop=$toolbar name=tb}
	{if $smarty.section.tb.first}<ul>{/if}
	<li{if $smarty.section.tb.first} class="first"{/if}><a href="#" onclick="document.forms.searchAction.elements.menuAction.value='{$toolbar[tb].link}'; submitBatch();">{$toolbar[tb].text|escape}</a></li>
	{if $smarty.section.tb.last}</ul>{/if}
	{/section}
	</th></tr>
	{/if}
	<tr>{if $checks}<th>{if $groupcount == 0}<input type="checkbox" name="group_check" onclick="javascript: toggle(this);">{/if}</th>{/if}{if $rownum}<th></th>{/if}{/if}{if !in_array($smarty.section.col.index, $groups)}<th>{$columns[col].title|escape}</th>{/if}{if $smarty.section.col.last}</tr></thead>{/if}
{/section}
{/strip}
{section loop=$footer name=item}
{if $smarty.section.item.first}<tfoot><tr>{if $checks}<td></td>{/if}{if $rownum}<td></td>{/if}{/if}{if !in_array($smarty.section.item.index, $groups)}<td class="{$columns[$smarty.section.item.index].type}">{$footer[item]|escape}</td>{/if}{if $smarty.section.item.last}</tr></tfoot>{/if}
{/section}
{section loop=$records name=row}
	{if $smarty.section.row.first}{strip}
		<tbody>
		{section loop=$groups name=group}
			{assign var=groupcol value=$groups[group]}
			{if $smarty.section.group.first}<tr class="group"><td colspan="{$colcount}">{/if}
			{if $checks}<input type="checkbox" name="group_check" onclick="javascript: toggle(this);">{/if}
			{$columns[$groupcol].title|escape}&nbsp;[&nbsp;{$records[row][$groupcol]|escape}&nbsp;]&nbsp;
			{if $smarty.section.group.last}</td></tr>{/if}
		{/section}
	{/strip}{elseif count($groups) > 0}{strip}
		{assign var=newgroup value=false}
		{foreach from=$groups item=value key=key}
			{if $records[row][$value] != $records[row.index_prev][$value]}
				{assign var=newgroup value=true}
			{/if}
		{/foreach}
		{if $newgroup == "true"}
			</tbody><tbody>
			{section loop=$groups name=group}
				{assign var=groupcol value=$groups[group]}
				{if $smarty.section.group.first}<tr class="group"><td colspan="{$colcount}">{/if}
				{if $checks}<input type="checkbox" name="group_check" onclick="javascript: toggle(this);">{/if}
				{$columns[$groupcol].title|escape}&nbsp;[&nbsp;{$records[row][$groupcol]|escape}&nbsp;]&nbsp;
				{if $smarty.section.group.last}</td></tr>{/if}
			{/section}
		{/if}{/strip}
	{/if}
	<tr{if $smarty.section.row.iteration is even} class="even"{/if}>
	{if $checks}{assign var=woid value=$groupcount}{assign var=seq value=$groupcount+1}<td class="rowcheck"><input type="checkbox" name="selected[]" value="{$records[row][$woid]}.{$records[row][$seq]}"></td>{/if}
	{if $rownum}<td class="rownum">{$smarty.section.row.iteration}</td>{/if}
	{section loop=$records[row] name=item}
		{if !in_array($smarty.section.item.index, $groups) && $smarty.section.item.index < (count($records[row]) + $VAL_ENDOFFSET)}<td class="{$columns[$smarty.section.item.index].type}">
			{if $columns[$smarty.section.item.index].type == "html"}{$records[row][item]}
			{else}
				{if $smarty.section.item.index < 2}<a href="{$URL_MAIN_PHP}?menuAction=boWorkorders.viewjcn&jcn={$records[row][0]}&seq={$records[row][1]}">{$records[row][item]|escape}</a>
				{elseif $smarty.section.item.index == $tag_ordinal && $records[row][$num_tags_ordinal] > 1}{dcl_get_entity_tags entity=$smarty.const.DCL_ENTITY_WORKORDER key_id=$records[row][0] key_id2=$records[row][1] link=Y}
				{elseif $smarty.section.item.index == $tag_ordinal && $records[row][$num_tags_ordinal] == 1}{dcl_tag_link value=$records[row][item]}
				{else}{$records[row][item]|escape}
				{/if}
			{/if}</td>
		{/if}
	{/section}
	</tr>
	{if $smarty.section.row.last}</tbody>{/if}
{/section}
</table>
{if $checks}</form>{/if}
