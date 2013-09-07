/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Beta  -- https://github.com/Vipeax/MinionRelogger   *
*  Copyright (C) 2013, Robert van den Boorn                                  *
*                                                                            *
*  This program is free software: you can redistribute it and/or modify      *
*   it under the terms of the GNU General Public License as published by     *
*   the Free Software Foundation, either version 3 of the License, or        *
*   (at your option) any later version.                                      *
*                                                                            *
*   This program is distributed in the hope that it will be useful,          *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*                                                                            *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Helpers.Language.Languages
{
    public class Turkish : Language
    {
        public Turkish()
        {
            // class: BreakObject
            Translations.Add(ETranslations.BreakObjectExpired, "Mola süresi {0} için doldu, yeni döngü başlatılıyor!");
            Translations.Add(ETranslations.BreakObjectNew, "Yeni Mola Başlatılışı: {0}, Yeni Mola Bitişi: {1}.");

            // class ComponentManager
            Translations.Add(ETranslations.ComponentManagerAddedComponent,
                " {0} isimli bir bileşen, listeye eklendi.");
            Translations.Add(ETranslations.ComponentManagerDisableComponent,
                " {0} isimli bir bileşen, devre dışı bırakıldı.");
            Translations.Add(ETranslations.ComponentManagerEnableComponent,
                " {0} isimli bir bileşen, aktif edildi.");

            // class: Config
            Translations.Add(ETranslations.ConfigNewAccount, "Yeni Hesap gayesi eklendi.");
            Translations.Add(ETranslations.ConfigErrorDuringEncryption, "Veriler şifrelenirken bir hata meydana geldi!");
            Translations.Add(ETranslations.ConfigOldSaveFileDeleted,
                "Eski kayıt dosyaları silinmiş, başka bir versiyona ait yada zarar görmüş olmalı!");
            Translations.Add(ETranslations.ConfigCouldntFindValidSaveFile,
                "Geçerli bir kayıt dosyası bulunamadı. Lütfen yeni bir kayıt dosyası oluşturunuz.");
            Translations.Add(ETranslations.ConfigDumpIntegers,
                "Polling Delay: {0}, Başlatma Gecikmesi: {1}, Yeniden Başlatma Gecikmesi: {2}, Donma Süresi: {3}.");

            // class: DataProtector
            Translations.Add(ETranslations.DataProtectorErrorOccured, "Veriler şifrelenirken bir hata meydana geldi!");
            Translations.Add(ETranslations.DataProtectorDeletedSaveFile,
                "Eski kayıt dosyaları silinmiş, başka bir versiyona ait yada zarar görmüş olmalı!");

            // class: General Settings
            Translations.Add(ETranslations.GeneralSettingsGW2PathChanged, "GW2 Yolu: [{0}] için değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsPollingDelayChanged,
                "Yoklama Gecikmesi: [{0}] için değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsFrozenTimeChanged,
                "Donma Süresi: [{0}] için değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsLaunchDelayChanged,
                "Başlatma Gecikmesi: [{0}] için değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsRestartDelayChanged,
                "Yeniden Başlatma Gecikmesi: [{0}] olarak değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsColorChanged, "Renk: {0} için değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsThemeChanged, "Tema: {0} için değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsMinimizeWindowsChanged,
                "Pencereleri Küçült: {0} için değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsCheckForIPChanged,
                "IP Kontrolü: {0} için değiştirildi.");
            Translations.Add(ETranslations.GeneralSettingsAddedIP,
                " {0} IP adresi, izin verilen IP adres listesine eklendi.");
            Translations.Add(ETranslations.GeneralSettingsDeletedIP,
                " {0} IP adresi, izin verilen IP adres listesinden silindi.");

            // class: GW2ManagerThread
            Translations.Add(ETranslations.GW2ManagerThreadStoppedResponding,
                " {0} ile çalışan bir GW2 clienti yanıt vermeyi kesti. Gözünüz üzerinde olsun.");
            Translations.Add(ETranslations.GW2ManagerThreadStartedRespondingAgain,
                " {0} ile çalışan GW2 clienti yeniden yanıt verir duruma geçti.");

            // class: InputBox
            Translations.Add(ETranslations.InputBoxOk, "OK");
            Translations.Add(ETranslations.InputBoxCancel, "İptal");

            // class: KillWorker
            Translations.Add(ETranslations.KillWorkerStoppingProcess, " {0} kimlikli işlem durduruluyor.");

            // class: StartWorker
            Translations.Add(ETranslations.StartWorkerLaunchingInstance, " {0} için client başlatılıyor {1} ile.");
            Translations.Add(ETranslations.StartWorkerScanningForExisting, "Şuanda çalışan GW2 clientleri taranıyor.");
            Translations.Add(ETranslations.StartWorkerFoundWantedProcess,
                " {0} için gerekli olan bir işlem bulundu, çalıştırmaya gerek yok.");
            Translations.Add(ETranslations.StartWorkerAttachingTo, " {0} a ekleniyor {1} ile.");

            // class: ViewStateObject
            Translations.Add(ETranslations.ViewStateObjectClientStuckSomewhere,
                " {0} ile çalışan GW2 clienti, {1} saniyeden beri yanıt vermiyor, yeniden başlatma için zamanlanıyor .");

            // class: WatchObject
            Translations.Add(ETranslations.WatchObjectNotRespondingFor,
                " {0} le çalışan GW2 clienti 90 saniyeden beri yanıt vermiyor, yeniden başlatma için zamanlanıyor.");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentPauseEvery, "Her Duraklatma"); // ... minutes 
            Translations.Add(ETranslations.BreakComponentDelayPrePause, "Rasgele Gecikmeli ön-duraklatma");
            // ... minutes
            Translations.Add(ETranslations.BreakComponentPause, "Duraklatma Zamanı"); // ... minutes
            Translations.Add(ETranslations.BreakComponentDelayPostPause, "Rasgele Gecikmeli atanan-duraklatma");
            // ... minutes
            Translations.Add(ETranslations.BreakComponentEnableBreaks, "Mola Aktif?");
            Translations.Add(ETranslations.BreakComponentMinutes, "dakika");
            Translations.Add(ETranslations.BreakComponentOk, "OK");
            Translations.Add(ETranslations.BreakComponentCancel, "İptal");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentDeleteIP, "IP Sil");
            Translations.Add(ETranslations.IPCheckComponentAddNewIP, "Yeni IP Ekle");
            Translations.Add(ETranslations.IPCheckComponentAddRange, "Aralık Ekle");
            Translations.Add(ETranslations.IPCheckComponentEnableIPChecks, "IP Kontrolünü Aktif Et?");
            Translations.Add(ETranslations.IPCheckComponentIPToAdd, "Eklenecek IP");
            Translations.Add(ETranslations.IPCheckComponentEnterIP,
                "Lütfen eklemeyi tercih etmiş olduğunuz IP'yi (Biçiminde giriniz: 127.0.0.1).");
            Translations.Add(ETranslations.IPCheckComponentAddingNewIPRange,
                "Yeni IP aralığı ekleniyor, son iki numaralı hane atlanacak, 192.168.1.1 şeklinde olacak 192.168.1.0-255. Buna rağmen geçerli bir IP adresi girin!");
            Translations.Add(ETranslations.IPCheckComponentIPRangeToAdd, "Eklenecek IP Aralığı");
            Translations.Add(ETranslations.IPCheckComponentEnterIPRange,
                "Lütfen eklemeyi tercih ettiğniz IP aralığını (Biçiminde giriniz: 192.168.1.0).");
            Translations.Add(ETranslations.IPCheckComponentOk, "OK");
            Translations.Add(ETranslations.IPCheckComponentCancel, "İptal");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentCurrentValue, "Güncel Değer:");
            Translations.Add(ETranslations.LaunchDelayComponentSeconds, "saniye");
            Translations.Add(ETranslations.LaunchDelayComponentSetNew, "Yeni Ayarla");
            Translations.Add(ETranslations.LaunchDelayComponentOk, "OK");
            Translations.Add(ETranslations.LaunchDelayComponentCancel, "İptal");
            Translations.Add(ETranslations.LaunchDelayComponentLaunchDelay, "Başlatma Gecikmesi");
            Translations.Add(ETranslations.LaunchDelayComponentEntireDesiredDelay,
                "Lütfen GW2 clientlerinin aralarındaki başlatma gecikmesiniz giriniz (!minimum: 20, saniye olmalı!).");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentCurrentValue, "Güncel Değer:");
            Translations.Add(ETranslations.RestartDelayComponentSeconds, "saniye");
            Translations.Add(ETranslations.RestartDelayComponentSetNew, "Yeni Ayarla");
            Translations.Add(ETranslations.RestartDelayComponentOk, "OK");
            Translations.Add(ETranslations.RestartDelayComponentCancel, "İptal");
            Translations.Add(ETranslations.RestartDelayComponentRestartDelay, "Yeniden Başlatma Gecikmesi");
            Translations.Add(ETranslations.RestartDelayComponentEntireDesiredDelay,
                "Lütfen GW2 clientlerinin aralarındaki yeniden başlatma gecikmesiniz giriniz (mevcut MMOMINION anahtarınızın desteklediği sayıyı bilerek) (!saniye olarak!).");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentStartTime, "Zamanı Başlat:");
            Translations.Add(ETranslations.SchedulerComponentStopTime, "Zamanı Durdur:");
            Translations.Add(ETranslations.SchedulerComponentDays, "Days (24s döngü):");
            Translations.Add(ETranslations.SchedulerComponentTimeInMinutes, "Dakikada Kaç kere:");
            Translations.Add(ETranslations.SchedulerComponentEnableScheduler, "Zamanlayıcıyı Aktif Et ?");
            Translations.Add(ETranslations.SchedulerComponentOk, "OK");
            Translations.Add(ETranslations.SchedulerComponentCancel, "İptal");
            Translations.Add(ETranslations.SchedulerComponentSaveSettings,
                "Zamanlayıcı {0} için kaydediliyor (dakika: {1}).");
            // class: AccountControl
            Translations.Add(ETranslations.AccountControlStart, "Başlat");
            Translations.Add(ETranslations.AccountControlStop, "Durdur");
            Translations.Add(ETranslations.AccountControlManage, "Yönet");
            Translations.Add(ETranslations.AccountControlSettings, "Ayarlar");
            Translations.Add(ETranslations.AccountControlEnabled, "Aktif");
            Translations.Add(ETranslations.AccountControlDisabled, "Devre Dışı");
            Translations.Add(ETranslations.AccountControlLoginName, "Giriş İsmi");
            Translations.Add(ETranslations.AccountControlStatus, "Durum");

            // GUI: AccountForm
            Translations.Add(ETranslations.AccountFormLoginName, "Giriş İsmi");
            Translations.Add(ETranslations.AccountFormPassword, "Şifre");
            Translations.Add(ETranslations.AccountFormNoSound, "Sessiz?");
            Translations.Add(ETranslations.AccountFormCancel, "İptal");
            Translations.Add(ETranslations.AccountFormDelete, "Sil");
            Translations.Add(ETranslations.AccountFormOk, "OK");
            Translations.Add(ETranslations.AccountFormAddAccount, "Hesap Ekle");
            Translations.Add(ETranslations.AccountFormEditAccount, "Hesap Düzenle");

            // GUI: MainForm
            Translations.Add(ETranslations.MainFormStartAll, "Hepsini Başlat");
            Translations.Add(ETranslations.MainFormStopAll, "Hepsini Durdur");
            Translations.Add(ETranslations.MainFormChangeTheme, "Temayı Değiştir");
            Translations.Add(ETranslations.MainFormChangeColor, "Rengi Değiştir");
            Translations.Add(ETranslations.MainFormAddAccount, "Hesap Ekle");
            Translations.Add(ETranslations.MainFormOpenSettings, "Ayarları Aç");
            Translations.Add(ETranslations.MainFormSetGW2EXEPath, "GW2 EXE Konumunu Belirle");
            Translations.Add(ETranslations.MainFormSetPollingDelay, "Yoklama Gecikmesini Ayarla");
            Translations.Add(ETranslations.MainFormSetFrozenTime, "Donma Süresini Ayarla");
            Translations.Add(ETranslations.MainFormMinimizeGW2Windows, "GW2 Pencerelerini Küçült?");
            Translations.Add(ETranslations.MainFormEnabledComponents, "Bileşenleri Aktif Et");
            Translations.Add(ETranslations.MainFormDisabledComponents, "Bileşenleri Engelle");
            Translations.Add(ETranslations.MainFormSetLanguage, "Dili Belirle");
            Translations.Add(ETranslations.MainFormMoveToRight, "Sağa Taşı");
            Translations.Add(ETranslations.MainFormMoveToLeft, "Sola Taşı");
            Translations.Add(ETranslations.MainFormLoad, "Yükle");
            Translations.Add(ETranslations.MainFormSave, "Kaydet");
            Translations.Add(ETranslations.MainFormAccounts, "Hesaplar");
            Translations.Add(ETranslations.MainFormSettings, "Ayarlar");
            Translations.Add(ETranslations.MainFormLog, "Log");
            Translations.Add(ETranslations.MainFormFreshConfig,
                "Merhaba, yeni ayarlarlamalar yapmaya karar verdiğiniz için, ayarlardaki birkaç adımı gözden geçirmelisiniz.");
            Translations.Add(ETranslations.MainFormWelcome, "Hoşgeldiniz");
            Translations.Add(ETranslations.MainFormWhichComponents,
                "Peki, şimdi Oyuna Yeniden Giriş Aracı için hangi bileşenleri kullanacağınızı seçmelisiniz. Eğer bunda acemiyseniz, hepsini aktif etmenizi öneririm. Bunu \"Sola Taşı\" düğmesine basarak yapabilirsiniz.");
            Translations.Add(ETranslations.MainFormFirstStep, "İlk Adım");
            Translations.Add(ETranslations.MainFormPleaseSave,
                "Ayarlamalarınızı yaptıktan sonra lütfen ayarlarınızı kaydetmeyi unutmayın, eğer bunu yapmazsanız bütün ayarları yeniden yapmak zorunda kalırsınız.");
            Translations.Add(ETranslations.MainFormTip, "İpucu!");
            Translations.Add(ETranslations.MainFormEnabled, "Aktif");
            Translations.Add(ETranslations.MainFormDisabled, "Devre Dışı");
            Translations.Add(ETranslations.MainFormLocateGW2Short, "GW2 Exe Konumunu Seç");
            Translations.Add(ETranslations.MainFormLocateGW2Long, "Lütfen GW2 exe Konumunu Seçiniz.");
            Translations.Add(ETranslations.MainFormPollingDelayShort, "Yoklama Gecikmesi");
            Translations.Add(ETranslations.MainFormPollingDelayLong,
                "Lütfen tercih edilen Yoklama Gecikmesini girin (!minimum: 3, saniye olmalı!).");
            Translations.Add(ETranslations.MainFormFrozenTimeShort, "Donma Süresi");
            Translations.Add(ETranslations.MainFormFrozenTimeLong,
                "Lütfen tercih ettiğiniz GW2 clientlerinin donma/takılma gibi durumlarda hangi GW2 clientinin ne kadar sürede kapanacağınızı giriniz (!minimum: 60, saniye olmalı!).");
            Translations.Add(ETranslations.MainFormLoginName, "Giriş İsmi");
            Translations.Add(ETranslations.MainFormStatus, "Durum");

            // component: BasicStopComponent
            Translations.Add(ETranslations.BasicStopComponentStop,
                " {0} için client durduruluyor, çalışmıyor olması gerekir (devre dışı).");
            Translations.Add(ETranslations.BasicStopComponentHalt,
                " {0} için aksayan başlatma, çalışmıyor olması gerekir (devre dışı).");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentKill,
                " {0} için client durduruluyor, mola ayarlarından dolayı çalışmıyor olmalı.");
            Translations.Add(ETranslations.BreakComponentHalt,
                " {0} için aksayan başlatma, mola ayarlarından dolayı başlatılamıyor olmalı.");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentHalt,
                " {0} için aksayan başlatma, çalıştıralamıyor. Şuanki IP'ye izin verilmemiş.");
            Translations.Add(ETranslations.IPCheckComponentKill,
                " {0} için client durduruldu, çalıştıralamıyor. Şuanki IP'ye izin verilmemiş.");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentHalt,
                " {0} için aksayan başlatma, çalıştıralamıyor. Başlatma Geciktirme zamanlaıcısının süresi henüz dolmamış.");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentHalt,
                " {0} için aksayan başlatma, çalıştıralamıyor. Başlatma Geciktirme zamanlayıcısının süresi henüz dolmamış.");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentHalt,
                " {0} için aksayan başlatma, çalıştırılamıyor. Zamanlayıcı ayarlarından dolayı çalışmıyor olmalı");
            Translations.Add(ETranslations.SchedulerComponentKill,
                " {0} için aksayan başlatma, çalıştırılamıyor. Zamanlayıcı ayarlarından dolayı çalışmıyor olmalı");
        }

        public override string GetLanguageDescription()
        {
            return "Türkçe";
        }

        public override ELanguages GetLanguage()
        {
            return ELanguages.Turkish;
        }
    }
}