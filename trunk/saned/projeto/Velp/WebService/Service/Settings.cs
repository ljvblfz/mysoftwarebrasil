namespace SANEDWebService.Properties {
    
    
    // Esta classe permite manipular eventos específicos na classe de configurações:
    //  O evento SettingChanging ocorre antes da alteração de um valor de configuração.
    //  O evento PropertyChanged ocorre após a alteração de um valor de configuração.
    //  O evento SettingsLoaded ocorre após o carregamento dos valores de configuração.
    //  O evento SettingsSaving ocorre antes de salvar os valores de configuração.
    internal sealed partial class Settings {
        
        public Settings() {
            // // Para adicionar os manipuladores de eventos para salvar e alterar as configurações, exclua os comentários das linhas a seguir:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Adicione o código para manipular o evento SettingChangingEvent aqui.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Adicione o código para manipular o evento SettingsSaving aqui.
        }
    }
}
