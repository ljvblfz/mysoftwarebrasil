<?php /* Smarty version 2.6.2, created on 2011-03-01 16:08:13
         compiled from htmlTable.tpl */ ?>
<?php require_once(SMARTY_DIR . 'core' . DIRECTORY_SEPARATOR . 'core.load_plugins.php');
smarty_core_load_plugins(array('plugins' => array(array('modifier', 'count', 'htmlTable.tpl', 2, false),array('modifier', 'escape', 'htmlTable.tpl', 7, false),)), $this); ?>
<!-- $Id: htmlTable.tpl 12 2006-12-01 01:46:51Z mdean $ -->
<?php $this->assign('groupcount', count($this->_tpl_vars['groups']));  $this->assign('colcount', count($this->_tpl_vars['columns']));  if ($this->_tpl_vars['rownum']):  $this->assign('colcount', $this->_tpl_vars['colcount']+1);  endif;  if ($this->_tpl_vars['checks']):  $this->assign('colcount', $this->_tpl_vars['colcount']+1);  endif; ?>
<table class="dcl_results<?php if ($this->_tpl_vars['inline']): ?> inline<?php endif; ?>"<?php if ($this->_tpl_vars['width'] > 0): ?> style="width:<?php echo $this->_tpl_vars['width']; ?>
;"<?php endif; ?>>
<?php if ($this->_tpl_vars['caption'] != ""): ?><caption<?php if ($this->_tpl_vars['spacer']): ?> class="spacer"<?php endif; ?>><?php echo ((is_array($_tmp=$this->_tpl_vars['caption'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>
</caption><?php endif;  if (isset($this->_sections['col'])) unset($this->_sections['col']);$this->_sections['col']['loop'] = is_array($_loop=$this->_tpl_vars['columns']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['col']['name'] = 'col';$this->_sections['col']['show'] = true;$this->_sections['col']['max'] = $this->_sections['col']['loop'];$this->_sections['col']['step'] = 1;$this->_sections['col']['start'] = $this->_sections['col']['step'] > 0 ? 0 : $this->_sections['col']['loop']-1;if ($this->_sections['col']['show']) {$this->_sections['col']['total'] = $this->_sections['col']['loop'];if ($this->_sections['col']['total'] == 0)$this->_sections['col']['show'] = false;} else$this->_sections['col']['total'] = 0;if ($this->_sections['col']['show']):for ($this->_sections['col']['index'] = $this->_sections['col']['start'], $this->_sections['col']['iteration'] = 1;$this->_sections['col']['iteration'] <= $this->_sections['col']['total'];$this->_sections['col']['index'] += $this->_sections['col']['step'], $this->_sections['col']['iteration']++):$this->_sections['col']['rownum'] = $this->_sections['col']['iteration'];$this->_sections['col']['index_prev'] = $this->_sections['col']['index'] - $this->_sections['col']['step'];$this->_sections['col']['index_next'] = $this->_sections['col']['index'] + $this->_sections['col']['step'];$this->_sections['col']['first']      = ($this->_sections['col']['iteration'] == 1);$this->_sections['col']['last']       = ($this->_sections['col']['iteration'] == $this->_sections['col']['total']); if ($this->_sections['col']['first']): ?><thead><?php if ($this->_tpl_vars['toolbar']): ?><tr class="toolbar"><th colspan="<?php echo $this->_tpl_vars['colcount']; ?>"><?php if (isset($this->_sections['tb'])) unset($this->_sections['tb']);$this->_sections['tb']['loop'] = is_array($_loop=$this->_tpl_vars['toolbar']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['tb']['name'] = 'tb';$this->_sections['tb']['show'] = true;$this->_sections['tb']['max'] = $this->_sections['tb']['loop'];$this->_sections['tb']['step'] = 1;$this->_sections['tb']['start'] = $this->_sections['tb']['step'] > 0 ? 0 : $this->_sections['tb']['loop']-1;if ($this->_sections['tb']['show']) {$this->_sections['tb']['total'] = $this->_sections['tb']['loop'];if ($this->_sections['tb']['total'] == 0)$this->_sections['tb']['show'] = false;} else$this->_sections['tb']['total'] = 0;if ($this->_sections['tb']['show']):for ($this->_sections['tb']['index'] = $this->_sections['tb']['start'], $this->_sections['tb']['iteration'] = 1;$this->_sections['tb']['iteration'] <= $this->_sections['tb']['total'];$this->_sections['tb']['index'] += $this->_sections['tb']['step'], $this->_sections['tb']['iteration']++):$this->_sections['tb']['rownum'] = $this->_sections['tb']['iteration'];$this->_sections['tb']['index_prev'] = $this->_sections['tb']['index'] - $this->_sections['tb']['step'];$this->_sections['tb']['index_next'] = $this->_sections['tb']['index'] + $this->_sections['tb']['step'];$this->_sections['tb']['first']      = ($this->_sections['tb']['iteration'] == 1);$this->_sections['tb']['last']       = ($this->_sections['tb']['iteration'] == $this->_sections['tb']['total']); if ($this->_sections['tb']['first']): ?><ul><?php endif; ?><li<?php if ($this->_sections['tb']['first']): ?> class="first"<?php endif; ?>><a href="<?php echo $this->_tpl_vars['toolbar'][$this->_sections['tb']['index']]['link']; ?>"><?php echo ((is_array($_tmp=$this->_tpl_vars['toolbar'][$this->_sections['tb']['index']]['text'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?></a></li><?php if ($this->_sections['tb']['last']): ?></ul><?php endif;  endfor; endif; ?></th></tr><?php endif; ?><tr><?php if ($this->_tpl_vars['checks']): ?><th><?php if ($this->_tpl_vars['groupcount'] == 0): ?><input type="checkbox" name="group_check" onclick="javascript: toggle(this);"><?php endif; ?></th><?php endif;  if ($this->_tpl_vars['rownum']): ?><th></th><?php endif;  endif;  if (! in_array ( $this->_sections['col']['index'] , $this->_tpl_vars['groups'] )): ?><th><?php echo ((is_array($_tmp=$this->_tpl_vars['columns'][$this->_sections['col']['index']]['title'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?></th><?php endif;  if ($this->_sections['col']['last']): ?></tr></thead><?php endif;  endfor; endif;  if (isset($this->_sections['item'])) unset($this->_sections['item']);
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
	<?php if ($this->_sections['row']['first']): ?><tbody><?php if (isset($this->_sections['group'])) unset($this->_sections['group']);$this->_sections['group']['loop'] = is_array($_loop=$this->_tpl_vars['groups']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['group']['name'] = 'group';$this->_sections['group']['show'] = true;$this->_sections['group']['max'] = $this->_sections['group']['loop'];$this->_sections['group']['step'] = 1;$this->_sections['group']['start'] = $this->_sections['group']['step'] > 0 ? 0 : $this->_sections['group']['loop']-1;if ($this->_sections['group']['show']) {$this->_sections['group']['total'] = $this->_sections['group']['loop'];if ($this->_sections['group']['total'] == 0)$this->_sections['group']['show'] = false;} else$this->_sections['group']['total'] = 0;if ($this->_sections['group']['show']):for ($this->_sections['group']['index'] = $this->_sections['group']['start'], $this->_sections['group']['iteration'] = 1;$this->_sections['group']['iteration'] <= $this->_sections['group']['total'];$this->_sections['group']['index'] += $this->_sections['group']['step'], $this->_sections['group']['iteration']++):$this->_sections['group']['rownum'] = $this->_sections['group']['iteration'];$this->_sections['group']['index_prev'] = $this->_sections['group']['index'] - $this->_sections['group']['step'];$this->_sections['group']['index_next'] = $this->_sections['group']['index'] + $this->_sections['group']['step'];$this->_sections['group']['first']      = ($this->_sections['group']['iteration'] == 1);$this->_sections['group']['last']       = ($this->_sections['group']['iteration'] == $this->_sections['group']['total']); $this->assign('groupcol', $this->_tpl_vars['groups'][$this->_sections['group']['index']]);  if ($this->_sections['group']['first']): ?><tr class="group"><td colspan="<?php echo $this->_tpl_vars['colcount']; ?>"><?php if ($this->_tpl_vars['checks']): ?><input type="checkbox" name="group_check" onclick="javascript: toggle(this);"><?php endif;  endif;  echo ((is_array($_tmp=$this->_tpl_vars['columns'][$this->_tpl_vars['groupcol']]['title'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>&nbsp;[&nbsp;<?php echo ((is_array($_tmp=$this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['groupcol']])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>&nbsp;]&nbsp;<?php if ($this->_sections['group']['last']): ?></td></tr><?php endif;  endfor; endif;  elseif (count ( $this->_tpl_vars['groups'] ) > 0):  $this->assign('newgroup', false);  if (count($_from = (array)$this->_tpl_vars['groups'])):foreach ($_from as $this->_tpl_vars['key'] => $this->_tpl_vars['value']): if ($this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['value']] != $this->_tpl_vars['records'][$this->_sections['row']['index_prev']][$this->_tpl_vars['value']]):  $this->assign('newgroup', true);  endif;  endforeach; unset($_from); endif;  if ($this->_tpl_vars['newgroup'] == 'true'): ?></tbody><tbody><?php if (isset($this->_sections['group'])) unset($this->_sections['group']);$this->_sections['group']['loop'] = is_array($_loop=$this->_tpl_vars['groups']) ? count($_loop) : max(0, (int)$_loop); unset($_loop);$this->_sections['group']['name'] = 'group';$this->_sections['group']['show'] = true;$this->_sections['group']['max'] = $this->_sections['group']['loop'];$this->_sections['group']['step'] = 1;$this->_sections['group']['start'] = $this->_sections['group']['step'] > 0 ? 0 : $this->_sections['group']['loop']-1;if ($this->_sections['group']['show']) {$this->_sections['group']['total'] = $this->_sections['group']['loop'];if ($this->_sections['group']['total'] == 0)$this->_sections['group']['show'] = false;} else$this->_sections['group']['total'] = 0;if ($this->_sections['group']['show']):for ($this->_sections['group']['index'] = $this->_sections['group']['start'], $this->_sections['group']['iteration'] = 1;$this->_sections['group']['iteration'] <= $this->_sections['group']['total'];$this->_sections['group']['index'] += $this->_sections['group']['step'], $this->_sections['group']['iteration']++):$this->_sections['group']['rownum'] = $this->_sections['group']['iteration'];$this->_sections['group']['index_prev'] = $this->_sections['group']['index'] - $this->_sections['group']['step'];$this->_sections['group']['index_next'] = $this->_sections['group']['index'] + $this->_sections['group']['step'];$this->_sections['group']['first']      = ($this->_sections['group']['iteration'] == 1);$this->_sections['group']['last']       = ($this->_sections['group']['iteration'] == $this->_sections['group']['total']); $this->assign('groupcol', $this->_tpl_vars['groups'][$this->_sections['group']['index']]);  if ($this->_sections['group']['first']): ?><tr class="group"><td colspan="<?php echo $this->_tpl_vars['colcount']; ?>"><?php if ($this->_tpl_vars['checks']): ?><input type="checkbox" name="group_check" onclick="javascript: toggle(this);"><?php endif;  endif;  echo ((is_array($_tmp=$this->_tpl_vars['columns'][$this->_tpl_vars['groupcol']]['title'])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>&nbsp;[&nbsp;<?php echo ((is_array($_tmp=$this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['groupcol']])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp)); ?>&nbsp;]&nbsp;<?php if ($this->_sections['group']['last']): ?></td></tr><?php endif;  endfor; endif;  endif; ?>
	<?php endif; ?>
	<tr<?php if (!(1 & $this->_sections['row']['iteration'])): ?> class="even"<?php endif; ?>>
	<?php if ($this->_tpl_vars['checks']): ?><td class="rowcheck"><input type="checkbox" name="selected[]" value="<?php echo $this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_tpl_vars['groupcount']]; ?>
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
 if (! in_array ( $this->_sections['item']['index'] , $this->_tpl_vars['groups'] )): ?><td class="<?php echo $this->_tpl_vars['columns'][$this->_sections['item']['index']]['type']; ?>
"><?php if ($this->_tpl_vars['columns'][$this->_sections['item']['index']]['type'] == 'html'):  echo $this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_sections['item']['index']];  else:  echo ((is_array($_tmp=$this->_tpl_vars['records'][$this->_sections['row']['index']][$this->_sections['item']['index']])) ? $this->_run_mod_handler('escape', true, $_tmp) : smarty_modifier_escape($_tmp));  endif; ?></td><?php endif;  endfor; endif; ?>
	</tr>
	<?php if ($this->_sections['row']['last']): ?></tbody><?php endif;  endfor; endif; ?>
</table>