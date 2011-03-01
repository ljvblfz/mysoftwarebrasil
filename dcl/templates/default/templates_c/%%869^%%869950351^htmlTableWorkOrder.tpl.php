<?php /* Smarty version 2.6.2, created on 2011-03-01 14:45:53
         compiled from htmlTableWorkOrder.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('function', 'dcl_select_status', 'htmlTableWorkOrder.tpl', 59, false),array('function', 'dcl_select_wo_type', 'htmlTableWorkOrder.tpl', 60, false),array('function', 'dcl_select_personnel', 'htmlTableWorkOrder.tpl', 61, false),array('function', 'dcl_select_product', 'htmlTableWorkOrder.tpl', 62, false),array('function', 'dcl_get_entity_tags', 'htmlTableWorkOrder.tpl', 143, false),array('function', 'dcl_tag_link', 'htmlTableWorkOrder.tpl', 144, false),array('modifier', 'count', 'htmlTableWorkOrder.tpl', 81, false),array('modifier', 'escape', 'htmlTableWorkOrder.tpl', 88, false),)), $this); ?>
<!-- $Id: htmlTableWorkOrder.tpl 74 2007-03-04 20:00:42Z mdean $ -->
<script language="JavaScript">
<?php echo '
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
	var sURL = \'main.php?menuAction=htmlWindowList.FrameRender&what=dcl_wo_account.wo_id&wo_id=\' + iWOID + \'&seq=\' + iSeq;
	var newWin = window.open(sURL, \'_dcl_selector_\', \'width=500,height=255\');
}

function submitBatch()
{
	var f = document.forms.searchAction;
	var sAction = f.elements.menuAction.value;

	if (sAction == \'boWorkorders.batchdetail\' || sAction == \'boTimecards.batchadd\' || sAction == \'boWorkorders.batchassign\' || sAction == \'htmlProjectmap.move\' || sAction == \'htmlProjectmap.batchmove\')
	{
		var bHasCheck = false;
		for (var i = 0; i < f.elements.length && !bHasCheck; i++)
		{
			bHasCheck = (f.elements[i].type == "checkbox" && f.elements[i].name != "group_check" && f.elements[i].checked);
		}

		if (!bHasCheck)
		{
			alert(\'You must select one or more items!\');
			return;
		}
	}
	f.submit();
}

function jumpToPage(iPage)
{
}
'; ?>

</script>
<div class="dcl_filter">
	<form name="pager" method="post" action="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
">
		<?php echo $this->_tpl_vars['VAL_VIEWSETTINGS']; ?>

		<input type="hidden" name="menuAction" value="<?php echo $this->_tpl_vars['VAL_FILTERMENUACTION']; ?>
" />
		<input type="hidden" name="startrow" value="<?php echo $this->_tpl_vars['VAL_FILTERSTARTROW']; ?>
" />
		<input type="hidden" name="numrows" value="<?php echo $this->_tpl_vars['VAL_FILTERNUMROWS']; ?>
" />
		<input type="hidden" name="jumptopage" value="<?php echo $this->_tpl_vars['VAL_PAGE']; ?>
" />
		<span><label for="filterStatus"><?php echo @constant('STR_WO_STATUS'); ?>
:</label> <?php echo smarty_function_dcl_select_status(array('default' => $this->_tpl_vars['VAL_FILTERSTATUS'],'name' => 'filterStatus','allowHideOrOnlyClosed' => 'Y'), $this);?>
</span>
		<span><label for="filterType"><?php echo @constant('STR_WO_TYPE'); ?>
:</label> <?php echo smarty_function_dcl_select_wo_type(array('default' => $this->_tpl_vars['VAL_FILTERTYPE'],'name' => 'filterType'), $this);?>
</span>
		<?php if (! $this->_tpl_vars['VAL_ISPUBLIC']): ?><span><label for="filterReportto"><?php echo @constant('STR_WO_RESPONSIBLE'); ?>
:</label> <?php echo smarty_function_dcl_select_personnel(array('default' => $this->_tpl_vars['VAL_FILTERREPORTTO'],'name' => 'filterReportto'), $this);?>
</span><?php endif; ?>
		<span><label for="filterProduct"><?php echo @constant('STR_WO_PRODUCT'); ?>
:</label> <?php echo smarty_function_dcl_select_product(array('default' => $this->_tpl_vars['VAL_FILTERPRODUCT'],'name' => 'filterProduct'), $this);?>
</span>
		<input type="submit" name="filter" value="Filter">
		<?php if ($this->_tpl_vars['VAL_PAGES'] > 1): ?>
			<div><ul><?php if ($this->_tpl_vars['VAL_PAGE'] > 1): ?><li class="first"><a href="#" onclick="forms.pager.jumptopage.value=<?php echo $this->_tpl_vars['VAL_PAGE']-1; ?>;forms.pager.submit();">&lt;&lt;</a></li><?php endif;  if ($this->_tpl_vars['VAL_PAGE'] > 5):  $this->assign('startpage', $this->_tpl_vars['VAL_PAGE']-5);  else:  $this->assign('startpage', 1);  endif;  if ($this->_tpl_vars['VAL_PAGE'] < ( $this->_tpl_vars['VAL_PAGES']-6 )):  $this->assign('endpage', $this->_tpl_vars['VAL_PAGE']+6);  else:  $this->assign('endpage', $this->_tpl_vars['VAL_PAGES']+1);  endif;  if (isset($this->_sections['iPage'])) unset($this->_sections['iPage']);$this->_sections['iPage']['name'] = 'iPage';$this->_sections['iPage']['start'] = (int)$this->_tpl_vars['startpage'];$this->_sections['iPage']['loop'] = is_array($_loop=$this->_tpl_vars['endpage']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['iPage']['step'] = ((int)1) == 0 ? 1 : (int)1;$this->_sections['iPage']['show'] = true;$this->_sections['iPage']['max'] = $this->_sections['iPage']['loop'];if ($this->_sections['iPage']['start'] < 0)$this->_sections['iPage']['start'] = max($this->_sections['iPage']['step'] > 0 ? 0 : -1, $this->_sections['iPage']['loop'] + $this->_sections['iPage']['start']);else$this->_sections['iPage']['start'] = min($this->_sections['iPage']['start'], $this->_sections['iPage']['step'] > 0 ? $this->_sections['iPage']['loop'] : $this->_sections['iPage']['loop']-1);if ($this->_sections['iPage']['show']) {$this->_sections['iPage']['total'] = min(ceil(($this->_sections['iPage']['step'] > 0 ? $this->_sections['iPage']['loop'] - $this->_sections['iPage']['start'] : $this->_sections['iPage']['start']+1)/abs($this->_sections['iPage']['step'])), $this->_sections['iPage']['max']);if ($this->_sections['iPage']['total'] == 0)$this->_sections['iPage']['show'] = false;} else$this->_sections['iPage']['total'] = 0;if ($this->_sections['iPage']['show']):for ($this->_sections['iPage']['index'] = $this->_sections['iPage']['start'], $this->_sections['iPage']['iteration'] = 1;$this->_sections['iPage']['iteration'] <= $this->_sections['iPage']['total'];$this->_sections['iPage']['index'] += $this->_sections['iPage']['step'], $this->_sections['iPage']['iteration']++):$this->_sections['iPage']['rownum'] = $this->_sections['iPage']['iteration'];$this->_sections['iPage']['index_prev'] = $this->_sections['iPage']['index'] - $this->_sections['iPage']['step'];$this->_sections['iPage']['index_next'] = $this->_sections['iPage']['index'] + $this->_sections['iPage']['step'];$this->_sections['iPage']['first']      = ($this->_sections['iPage']['iteration'] == 1);$this->_sections['iPage']['last']       = ($this->_sections['iPage']['iteration'] == $this->_sections['iPage']['total']);?><li<?php if ($this->_sections['iPage']['first'] && $this->_tpl_vars['VAL_PAGE'] < 2): ?> class="first"<?php endif; ?>><?php if ($this->_sections['iPage']['index'] == $this->_tpl_vars['VAL_PAGE']): ?><strong><?php echo $this->_tpl_vars['VAL_PAGE']; ?></strong><?php else: ?><a href="#" onclick="forms.pager.jumptopage.value=<?php echo $this->_sections['iPage']['index']; ?>;forms.pager.submit();"><?php echo $this->_sections['iPage']['index']; ?></a><?php endif; ?></li><?php endfor; endif;  if ($this->_tpl_vars['VAL_PAGE'] < $this->_tpl_vars['VAL_PAGES']): ?><li><a href="#" onclick="forms.pager.jumptopage.value=<?php echo $this->_tpl_vars['VAL_PAGE']+1; ?>;forms.pager.submit();">&gt;&gt;</a></li><?php endif; ?></ul></div>
		<?php endif; ?>
	</form>
</div>
<?php $this->assign('groupcount', count($this->_tpl_vars['groups']));  $this->assign('colcount', count($this->_tpl_vars['columns']));  if ($this->_tpl_vars['rownum']):  $this->assign('colcount', $this->_tpl_vars['colcount']+1);  endif;  if ($this->_tpl_vars['checks']):  $this->assign('colcount', $this->_tpl_vars['colcount']+1); ?>
	<form name="searchAction" method="post" action="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
"><input type="hidden" name="menuAction" value="" /><?php echo $this->_tpl_vars['VAL_VIEWSETTINGS']; ?>

<?php endif; ?>
<table class="dcl_results<?php if ($this->_tpl_vars['inline']): ?> inline<?php endif; ?>">
<?php if ($this->_tpl_vars['caption'] != ""): ?><caption><?php echo ((is_array($_tmp=$this->_tpl_vars['caption'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</caption><?php endif;  if (isset($this->_sections['col'])) unset($this->_sections['col']);$this->_sections['col']['loop'] = is_array($_loop=$this->_tpl_vars['columns']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['col']['name'] = 'col';$this->_sections['col']['show'] = true;$this->_sections['col']['max'] = $this->_sections['col']['loop'];$this->_sections['col']['step'] = 1;$this->_sections['col']['start'] = $this->_sections['col']['step'] > 0 ? 0 : $this->_sections['col']['loop']-1;if ($this->_sections['col']['show']) {$this->_sections['col']['total'] = $this->_sections['col']['loop'];if ($this->_sections['col']['total'] == 0)$this->_sections['col']['show'] = false;} else$this->_sections['col']['total'] = 0;if ($this->_sections['col']['show']):for ($this->_sections['col']['index'] = $this->_sections['col']['start'], $this->_sections['col']['iteration'] = 1;$this->_sections['col']['iteration'] <= $this->_sections['col']['total'];$this->_sections['col']['index'] += $this->_sections['col']['step'], $this->_sections['col']['iteration']++):$this->_sections['col']['rownum'] = $this->_sections['col']['iteration'];$this->_sections['col']['index_prev'] = $this->_sections['col']['index'] - $this->_sections['col']['step'];$this->_sections['col']['index_next'] = $this->_sections['col']['index'] + $this->_sections['col']['step'];$this->_sections['col']['first']      = ($this->_sections['col']['iteration'] == 1);$this->_sections['col']['last']       = ($this->_sections['col']['iteration'] == $this->_sections['col']['total']); if ($this->_sections['col']['first']): ?><thead><?php if ($this->_tpl_vars['toolbar']): ?><tr class="toolbar"><th colspan="<?php echo $this->_tpl_vars['colcount']; ?>"><?php if (isset($this->_sections['tb'])) unset($this->_sections['tb']);$this->_sections['tb']['loop'] = is_array($_loop=$this->_tpl_vars['toolbar']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['tb']['name'] = 'tb';$this->_sections['tb']['show'] = true;$this->_sections['tb']['max'] = $this->_sections['tb']['loop'];$this->_sections['tb']['step'] = 1;$this->_sections['tb']['start'] = $this->_sections['tb']['step'] > 0 ? 0 : $this->_sections['tb']['loop']-1;if ($this->_sections['tb']['show']) {$this->_sections['tb']['total'] = $this->_sections['tb']['loop'];if ($this->_sections['tb']['total'] == 0)$this->_sections['tb']['show'] = false;} else$this->_sections['tb']['total'] = 0;if ($this->_sections['tb']['show']):for ($this->_sections['tb']['index'] = $this->_sections['tb']['start'], $this->_sections['tb']['iteration'] = 1;$this->_sections['tb']['iteration'] <= $this->_sections['tb']['total'];$this->_sections['tb']['index'] += $this->_sections['tb']['step'], $this->_sections['tb']['iteration']++):$this->_sections['tb']['rownum'] = $this->_sections['tb']['iteration'];$this->_sections['tb']['index_prev'] = $this->_sections['tb']['index'] - $this->_sections['tb']['step'];$this->_sections['tb']['index_next'] = $this->_sections['tb']['index'] + $this->_sections['tb']['step'];$this->_sections['tb']['first']      = ($this->_sections['tb']['iteration'] == 1);$this->_sections['tb']['last']       = ($this->_sections['tb']['iteration'] == $this->_sections['tb']['total']); if ($this->_sections['tb']['first']): ?><ul><?php endif; ?><li<?php if ($this->_sections['tb']['first']): ?> class="first"<?php endif; ?>><a href="#" onclick="document.forms.searchAction.elements.menuAction.value='<?php echo $this->_tpl_vars['toolbar'][$this->_sections['tb']['index']]['link']; ?>'; submitBatch();"><?php echo ((is_array($_tmp=$this->_tpl_vars['toolbar'][$this->_sections['tb']['index']]['text'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?></a></li><?php if ($this->_sections['tb']['last']): ?></ul><?php endif;  endfor; endif; ?></th></tr><?php endif; ?><tr><?php if ($this->_tpl_vars['checks']): ?><th><?php if ($this->_tpl_vars['groupcount'] == 0): ?><input type="checkbox" name="group_check" onclick="javascript: toggle(this);"><?php endif; ?></th><?php endif;  if ($this->_tpl_vars['rownum']): ?><th></th><?php endif;  endif;  if (! in_array ( $this->_sections['col']['index'] , $this->_tpl_vars['groups'] )): ?><th><?php echo ((is_array($_tmp=$this->_tpl_vars['columns'][$this->_sections['col']['index']]['title'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?></th><?php endif;  if ($this->_sections['col']['last']): ?></tr></thead><?php endif;  endfor; endif;  if (isset($this->_sections['item'])) unset($this->_sections['item']);
$this->_sections['item']['loop'] = is_array($_loop=$this->_tpl_vars['footer']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['item']['name'] = 'item';
$this->_sections['item']['show'] = true;
$this->_sections['item']['max'] = $this->_sections['item']['loop'];
$this->_sections['item']['step'] = 1;
$this->_sections['item']['start'] = $this->_sections['item']['step'] > 0 ? 0 : $this->_sections['item']['loop']-1;
if ($this->_sections['item']['show']) {
    $this->_sections['item']['total'] = $this->_sections['item']['loop'];
    if ($this->_sections['item']['total'] == 0)
        $this->_sections['item']['show'] = false;
} else
    $this->_sections['item']['total'] = 0;
if ($this->_sections['item']['show']):

            for ($this->_sections['item']['index'] = $this->_sections['item']['start'], $this->_sections['item']['iteration'] = 1;
                 $this->_sections['item']['iteration'] <= $this->_sections['item']['total'];
                 $this->_sections['item']['index'] += $this->_sections['item']['step'], $this->_sections['item']['iteration']++):
$this->_sections['item']['rownum'] = $this->_sections['item']['iteration'];
$this->_sections['item']['index_prev'] = $this->_sections['item']['index'] - $this->_sections['item']['step'];
$this->_sections['item']['index_next'] = $this->_sections['item']['index'] + $this->_sections['item']['step'];
$this->_sections['item']['first']      = ($this->_sections['item']['iteration'] == 1);
$this->_sections['item']['last']       = ($this->_sections['item']['iteration'] == $this->_sections['item']['total']);
 if ($this->_sections['item']['first']): ?><tfoot><tr><?php if ($this->_tpl_vars['checks']): ?><td></td><?php endif;  if ($this->_tpl_vars['rownum']): ?><td></td><?php endif;  endif;  if (! in_array ( $this->_sections['item']['index'] , $this->_tpl_vars['groups'] )): ?><td class="<?php echo $this->_tpl_vars['columns'][$this->_sections['item']['index']]['type']; ?>
"><?php echo ((is_array($_tmp=$this->_tpl_vars['footer'][$this->_sections['item']['index']])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</td><?php endif;  if ($this->_sections['item']['last']): ?></tr></tfoot><?php endif;  endfor; endif;  if (isset($this->_sections['row'])) unset($this->_sections['row']);
$this->_sections['row']['loop'] = is_array($_loop=$this->_tpl_vars['records']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['row']['name'] = 'row';
$this->_sections['row']['show'] = true;
$this->_sections['row']['max'] = $this->_sections['row']['loop'];
$this->_sections['row']['step'] = 1;
$this->_sections['row']['start'] = $this->_sections['row']['step'] > 0 ? 0 : $this->_sections['row']['loop']-1;
if ($this->_sections['row']['show']) {
    $this->_sections['row']['total'] = $this->_sections['row']['loop'];
    if ($this->_sections['row']['total'] == 0)
        $this->_sections['row']['show'] = false;
} else
    $this->_sections['row']['total'] = 0;
if ($this->_sections['row']['show']):

            for ($this->_sections['row']['index'] = $this->_sections['row']['start'], $this->_sections['row']['iteration'] = 1;
                 $this->_sections['row']['iteration'] <= $this->_sections['row']['total'];
                 $this->_sections['row']['index'] += $this->_sections['row']['step'], $this->_sections['row']['iteration']++):
$this->_sections['row']['rownum'] = $this->_sections['row']['iteration'];
$this->_sections['row']['index_prev'] = $this->_sections['row']['index'] - $this->_sections['row']['step'];
$this->_sections['row']['index_next'] = $this->_sections['row']['index'] + $this->_sections['row']['step'];
$this->_sections['row']['first']      = ($this->_sections['row']['iteration'] == 1);
$this->_sections['row']['last']       = ($this->_sections['row']['iteration'] == $this->_sections['row']['total']);
?>
	<?php if ($this->_sections['row']['first']): ?><tbody><?php if (isset($this->_sections['group'])) unset($this->_sections['group']);$this->_sections['group']['loop'] = is_array($_loop=$this->_tpl_vars['groups']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['group']['name'] = 'group';$this->_sections['group']['show'] = true;$this->_sections['group']['max'] = $this->_sections['group']['loop'];$this->_sections['group']['step'] = 1;$this->_sections['group']['start'] = $this->_sections['group']['step'] > 0 ? 0 : $this->_sections['group']['loop']-1;if ($this->_sections['group']['show']) {$this->_sections['group']['total'] = $this->_sections['group']['loop'];if ($this->_sections['group']['total'] == 0)$this->_sections['group']['show'] = false;} else$this->_sections['group']['total'] = 0;if ($this->_sections['group']['show']):for ($this->_sections['group']['index'] = $this->_sections['group']['start'], $this->_sections['group']['iteration'] = 1;$this->_sections['group']['iteration'] <= $this->_sections['group']['total'];$this->_sections['group']['index'] += $this->_sections['group']['step'], $this->_sections['group']['iteration']++):$this->_sections['group']['rownum'] = $this->_sections['group']['iteration'];$this->_sections['group']['index_prev'] = $this->_sections['group']['index'] - $this->_sections['group']['step'];$this->_sections['group']['index_next'] = $this->_sections['group']['index'] + $this->_sections['group']['step'];$this->_sections['group']['first']      = ($this->_sections['group']['iteration'] == 1);$this->_sections['group']['last']       = ($this->_sections['group']['iteration'] == $this->_sections['group']['total']); $this->assign('groupcol', $this->_tpl_vars['groups'][$this->_sections['group']['index']]);  if ($this->_sections['group']['first']): ?><tr class="group"><td colspan="<?php echo $this->_tpl_vars['colcount']; ?>"><?php endif;  if ($this->_tpl_vars['checks']): ?><input type="checkbox" name="group_check" onclick="javascript: toggle(this);"><?php endif;  echo ((is_array($_tmp=$this->_tpl_vars['columns'][$this->_tpl_vars['groupcol']]['title'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>&nbsp;[&nbsp;<?php echo ((is_array($_tmp=$this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['groupcol']])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>&nbsp;]&nbsp;<?php if ($this->_sections['group']['last']): ?></td></tr><?php endif;  endfor; endif;  elseif (count ( $this->_tpl_vars['groups'] ) > 0):  $this->assign('newgroup', false);  if (count($_from = (array)$this->_tpl_vars['groups'])):foreach ($_from as $this->_tpl_vars['key'] => $this->_tpl_vars['value']): if ($this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['value']] != $this->_tpl_vars['records'][$this->_sections['row']['index_prev']][$this->_tpl_vars['value']]):  $this->assign('newgroup', true);  endif;  endforeach; unset($_from); endif;  if ($this->_tpl_vars['newgroup'] == 'true'): ?></tbody><tbody><?php if (isset($this->_sections['group'])) unset($this->_sections['group']);$this->_sections['group']['loop'] = is_array($_loop=$this->_tpl_vars['groups']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['group']['name'] = 'group';$this->_sections['group']['show'] = true;$this->_sections['group']['max'] = $this->_sections['group']['loop'];$this->_sections['group']['step'] = 1;$this->_sections['group']['start'] = $this->_sections['group']['step'] > 0 ? 0 : $this->_sections['group']['loop']-1;if ($this->_sections['group']['show']) {$this->_sections['group']['total'] = $this->_sections['group']['loop'];if ($this->_sections['group']['total'] == 0)$this->_sections['group']['show'] = false;} else$this->_sections['group']['total'] = 0;if ($this->_sections['group']['show']):for ($this->_sections['group']['index'] = $this->_sections['group']['start'], $this->_sections['group']['iteration'] = 1;$this->_sections['group']['iteration'] <= $this->_sections['group']['total'];$this->_sections['group']['index'] += $this->_sections['group']['step'], $this->_sections['group']['iteration']++):$this->_sections['group']['rownum'] = $this->_sections['group']['iteration'];$this->_sections['group']['index_prev'] = $this->_sections['group']['index'] - $this->_sections['group']['step'];$this->_sections['group']['index_next'] = $this->_sections['group']['index'] + $this->_sections['group']['step'];$this->_sections['group']['first']      = ($this->_sections['group']['iteration'] == 1);$this->_sections['group']['last']       = ($this->_sections['group']['iteration'] == $this->_sections['group']['total']); $this->assign('groupcol', $this->_tpl_vars['groups'][$this->_sections['group']['index']]);  if ($this->_sections['group']['first']): ?><tr class="group"><td colspan="<?php echo $this->_tpl_vars['colcount']; ?>"><?php endif;  if ($this->_tpl_vars['checks']): ?><input type="checkbox" name="group_check" onclick="javascript: toggle(this);"><?php endif;  echo ((is_array($_tmp=$this->_tpl_vars['columns'][$this->_tpl_vars['groupcol']]['title'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>&nbsp;[&nbsp;<?php echo ((is_array($_tmp=$this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['groupcol']])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>&nbsp;]&nbsp;<?php if ($this->_sections['group']['last']): ?></td></tr><?php endif;  endfor; endif;  endif; ?>
	<?php endif; ?>
	<tr<?php if (!(1 & $this->_sections['row']['iteration'])): ?> class="even"<?php endif; ?>>
	<?php if ($this->_tpl_vars['checks']):  $this->assign('woid', $this->_tpl_vars['groupcount']);  $this->assign('seq', $this->_tpl_vars['groupcount']+1); ?><td class="rowcheck"><input type="checkbox" name="selected[]" value="<?php echo $this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['woid']]; ?>
.<?php echo $this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['seq']]; ?>
"></td><?php endif; ?>
	<?php if ($this->_tpl_vars['rownum']): ?><td class="rownum"><?php echo $this->_sections['row']['iteration']; ?>
</td><?php endif; ?>
	<?php if (isset($this->_sections['item'])) unset($this->_sections['item']);
$this->_sections['item']['loop'] = is_array($_loop=$this->_tpl_vars['records'][$this->_sections['row']['index']]) ? count($_loop) : max(0, (int)$_loop); unset($_loop);
$this->_sections['item']['name'] = 'item';
$this->_sections['item']['show'] = true;
$this->_sections['item']['max'] = $this->_sections['item']['loop'];
$this->_sections['item']['step'] = 1;
$this->_sections['item']['start'] = $this->_sections['item']['step'] > 0 ? 0 : $this->_sections['item']['loop']-1;
if ($this->_sections['item']['show']) {
    $this->_sections['item']['total'] = $this->_sections['item']['loop'];
    if ($this->_sections['item']['total'] == 0)
        $this->_sections['item']['show'] = false;
} else
    $this->_sections['item']['total'] = 0;
if ($this->_sections['item']['show']):

            for ($this->_sections['item']['index'] = $this->_sections['item']['start'], $this->_sections['item']['iteration'] = 1;
                 $this->_sections['item']['iteration'] <= $this->_sections['item']['total'];
                 $this->_sections['item']['index'] += $this->_sections['item']['step'], $this->_sections['item']['iteration']++):
$this->_sections['item']['rownum'] = $this->_sections['item']['iteration'];
$this->_sections['item']['index_prev'] = $this->_sections['item']['index'] - $this->_sections['item']['step'];
$this->_sections['item']['index_next'] = $this->_sections['item']['index'] + $this->_sections['item']['step'];
$this->_sections['item']['first']      = ($this->_sections['item']['iteration'] == 1);
$this->_sections['item']['last']       = ($this->_sections['item']['iteration'] == $this->_sections['item']['total']);
?>
		<?php if (! in_array ( $this->_sections['item']['index'] , $this->_tpl_vars['groups'] ) && $this->_sections['item']['index'] < ( count ( $this->_tpl_vars['records'][$this->_sections['row']['index']] ) + $this->_tpl_vars['VAL_ENDOFFSET'] )): ?><td class="<?php echo $this->_tpl_vars['columns'][$this->_sections['item']['index']]['type']; ?>
">
			<?php if ($this->_tpl_vars['columns'][$this->_sections['item']['index']]['type'] == 'html'):  echo $this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_sections['item']['index']]; ?>

			<?php else: ?>
				<?php if ($this->_sections['item']['index'] < 2): ?><a href="<?php echo $this->_tpl_vars['URL_MAIN_PHP']; ?>
?menuAction=boWorkorders.viewjcn&jcn=<?php echo $this->_tpl_vars['records'][$this->_sections['row']['index']][0]; ?>
&seq=<?php echo $this->_tpl_vars['records'][$this->_sections['row']['index']][1]; ?>
"><?php echo ((is_array($_tmp=$this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_sections['item']['index']])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</a>
				<?php elseif ($this->_sections['item']['index'] == $this->_tpl_vars['tag_ordinal'] && $this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['num_tags_ordinal']] > 1):  echo smarty_function_dcl_get_entity_tags(array('entity' => @constant('DCL_ENTITY_WORKORDER'),'key_id' => $this->_tpl_vars['records'][$this->_sections['row']['index']][0],'key_id2' => $this->_tpl_vars['records'][$this->_sections['row']['index']][1],'link' => 'Y'), $this);?>

				<?php elseif ($this->_sections['item']['index'] == $this->_tpl_vars['tag_ordinal'] && $this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['num_tags_ordinal']] == 1):  echo smarty_function_dcl_tag_link(array('value' => $this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_sections['item']['index']]), $this);?>

				<?php else:  echo ((is_array($_tmp=$this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_sections['item']['index']])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>

				<?php endif; ?>
			<?php endif; ?></td>
		<?php endif; ?>
	<?php endfor; endif; ?>
	</tr>
	<?php if ($this->_sections['row']['last']): ?></tbody><?php endif;  endfor; endif; ?>
</table>
<?php if ($this->_tpl_vars['checks']): ?></form><?php endif; ?>