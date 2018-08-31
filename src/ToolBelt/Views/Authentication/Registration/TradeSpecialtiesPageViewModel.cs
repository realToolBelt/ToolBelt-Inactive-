using Prism.Navigation;
using Prism.Services;
using ReactiveUI;
using System.Linq;
using System.Reactive.Linq;
using ToolBelt.ViewModels;

namespace ToolBelt.Views.Authentication.Registration
{
    // TODO: Most of this page should be moved into a content view rather than a page.  Then we could share it across the registration and profile editing pages.
    public class TradeSpecialtiesPageViewModel : BaseViewModel
    {
        public TradeSpecialtiesPageViewModel(
            INavigationService navigationService,
            IPageDialogService dialogService) : base(navigationService)
        {
            Title = "Trade Specialties";

            SelectAll = ReactiveCommand.Create(() =>
            {
                foreach (var item in Items)
                {
                    item.IsSelected = true;
                }
            });

            SelectNone = ReactiveCommand.Create(() =>
            {
                foreach (var item in Items)
                {
                    item.IsSelected = false;
                }
            });

            Next = ReactiveCommand.CreateFromTask(async () =>
            {
                // if there are no items selected, they can't move on.  Must select at least one specialty
                if (!Items.Any(item => item.IsSelected))
                {
                    await dialogService.DisplayAlertAsync("Error", "You must select at least one trade specialty", "OK").ConfigureAwait(false);
                }

                // TODO: ...

            });

            Items.AddRange(
                new[]
                {
                    "Laborer",
                    "Carpenter",
                    "Construction manager",
                    "Painter",
                    "Admin support",
                    "Plumber",
                    "Professional",
                    "Heat A/C mech",
                    "Operating engineer",
                    "Repairer",
                    "Manager",
                    "Electrician",
                    "Roofer",
                    "Truck driver",
                    "Brickmason",
                    "Foreman",
                    "Service",
                    "Drywall",
                    "Welder",
                    "Carpet and tile",
                    "Material moving",
                    "Concrete",
                    "Ironworker",
                    "Helper",
                    "Insulation",
                    "Sheet metal",
                    "Fence Erector",
                    "Highway Maint",
                    "Misc worker",
                    "Inspector",
                    "Glazier",
                    "Plasterer",
                    "Dredge",
                    "Power-line installer",
                    "Driller",
                    "Elevator",
                    "Paving",
                    "Iron reinforcement",
                    "Boilermaker",
                    "Other"
                }
                .Select(community => new SelectionViewModel<string>(community)));
        }

        public ReactiveList<SelectionViewModel<string>> Items { get; } = new ReactiveList<SelectionViewModel<string>>();

        public ReactiveCommand Next { get; }

        public ReactiveCommand SelectAll { get; }

        public ReactiveCommand SelectNone { get; }
    }
}