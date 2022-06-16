using UnityEngine;
using MyGame.Tools;
using System;

namespace MyGame.Features.AbilitySystem
{
    internal class AbilityController : BaseController
    {
        private readonly ResourcePath viewPath = new ResourcePath("Prefabs/Abilities/AbilityView");
        private readonly ResourcePath dataSourcePath = new ResourcePath("Configs/Abilities/AbilityItemConfigDataSource");

        private readonly AbilitiesView view;
        private readonly AbilityRepository repository;
        private readonly IAbilityActivator abilityActivator;

        public AbilityController(Transform placeForUI, IAbilityActivator abilityActivator)
        {
            if (placeForUI == null)
                throw new ArgumentNullException(nameof(placeForUI));

            this.abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));

            var abilityItemConfig = LoadAbilityItemConfigs();
            repository = CreateRepository(abilityItemConfig);
            view = LoadView(placeForUI);
            view.Display(abilityItemConfig, OnAbilityViewClicked);

        }

        private AbilityRepository CreateRepository(AbilityItemConfig[] dataConfigs)
        {
            AbilityRepository repository =  new AbilityRepository(dataConfigs);
            AddRepository(repository);
            return repository;
        }

        private void OnAbilityViewClicked(string itemId)
        {
            if (repository.Items.TryGetValue(itemId, out IAbility ability))
                ability.Apply(abilityActivator);
        }

        private AbilitiesView LoadView(Transform placeForView)
        {
            var viewPref = ResourceLoader.LoadObject<GameObject>(viewPath);
            var view = UnityEngine.Object.Instantiate(viewPref, placeForView, false);
            return view.GetComponent<AbilitiesView>();
        }

        private AbilityItemConfig[] LoadAbilityItemConfigs() =>
            ContentDataSourceLoader.LoadAbilityItemConfigs(dataSourcePath);


    }
}
