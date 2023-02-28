using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.ViewModels.ValueChangedMessage;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels
{
    public enum TerstType
    {
        All,
        Service,
        Personal,
        Thirdparties,
        Marketings
    }

    public partial class TermsViewModel : ObservableObject
    {
        private TerstType tersValue;
        [ObservableProperty]
        private string titleText;

        private bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                SetProperty(ref isChecked, value);
                WeakReferenceMessenger.Default.Send(
                    new CheckStateChangedMessage(
                        new CheckStateMessage()
                        {
                            type = tersValue,
                            state = value
                        })
                    );
            }
        }

        [ObservableProperty]
        private bool isSubPage = false;

        public TermsViewModel SetType(TerstType type)
        {
            this.tersValue = type;
            return this;
        }
        public TermsViewModel SetTitle(string titleText)
        {
            this.TitleText = titleText;
            return this;
        }

        public TermsViewModel SetSubTitleEnabled()
        {
            this.IsSubPage = true;
            return this;
        }

        public TerstType GetTerstType() => this.tersValue;
        public void CheckStateChange(bool state) => this.IsChecked = state;
        public bool GetEssentialTerm() => this.IsSubPage == true;
        public bool IsCheckTrue() => this.IsChecked == true;

        [RelayCommand]
        private void Area()
        {
            this.IsChecked = !this.IsChecked;
            WeakReferenceMessenger.Default.Send(new CheckStateChangedMessage(new CheckStateMessage()
            {
                type = tersValue,
                state = this.IsChecked
            }));
        }

    }
    public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TermsViewModel> termsViewModel = new ObservableCollection<TermsViewModel>();

        [ObservableProperty]
        private bool nextButtonEnable = false;

        public RegisterViewModel()
        {
            TermsViewModel.Add(new TermsViewModel()
                                   .SetType(TerstType.All)
                                   .SetTitle("전체동의"));
            TermsViewModel.Add(new TermsViewModel()
                                   .SetType(TerstType.Service)
                                   .SetTitle("서비스 이용약관 (필수)")
                                   .SetSubTitleEnabled());
            TermsViewModel.Add(new TermsViewModel()
                                   .SetType(TerstType.Personal)
                                   .SetTitle("개인정보 수집 및 이용 (필수)")
                                   .SetSubTitleEnabled());
            TermsViewModel.Add(new TermsViewModel()
                                   .SetType(TerstType.Thirdparties)
                                   .SetTitle("개인정보 제3자 정보제공 동의 (필수)")
                                   .SetSubTitleEnabled());
            TermsViewModel.Add(new TermsViewModel()
                                   .SetType(TerstType.Marketings)
                                   .SetTitle("마케팅 정보 수신 동의 (선택)"));
        }
    }
}
