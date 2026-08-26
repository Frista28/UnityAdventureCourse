using _31.Scripts.Characters;
using _31.Scripts.Characters.Configs;
using _31.Scripts.Characters.Creation;
using _31.Scripts.Characters.Creation.Components.Weapon.RangeWeapon;
using _31.Scripts.Characters.Creation.Controllers.Movement;
using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Components.Health;
using _31.Scripts.Components.Movement;
using _31.Scripts.Components.Movement.Controller;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Creators;
using _31.Scripts.Hits.Data.Config;
using _31.Scripts.Hits.Data.CustomData.Damage;
using _31.Scripts.Inputs;
using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Inputs.Creators;
using _31.Scripts.Interaction.Service.Hit.Damage;
using _31.Scripts.Lifecycle;
using _31.Scripts.Targets;
using UnityEngine;

namespace _31.Scripts.Infrastructure.Composition
{
    public class PlayerComposition
    {
        private readonly RangeWeaponUserCharacter _prefab;
        private readonly CharacterConfig _characterConfig;
        private readonly MovementInputConfig _movementInputConfig;
        private readonly HitRangeWeaponConfig _weaponConfig;

        private readonly ICharacterCreator<RangeWeaponUserCharacter> _characterCreator;

        public PlayerComposition(
            RangeWeaponUserCharacter prefab,
            CharacterConfig characterConfig,
            MovementInputConfig movementInputConfig,
            HitRangeWeaponConfig weaponConfig,
            UpdateService updateService,
            MovementControllerUpdateService movementControllerUpdateService,
            TargetProvider targetProvider)
        {
            _prefab = prefab;
            _characterConfig = characterConfig;
            _movementInputConfig = movementInputConfig;
            _weaponConfig = weaponConfig;

            _characterCreator = CreateCharacterCreator(
                updateService,
                movementControllerUpdateService,
                targetProvider);
        }
        
        public RangeWeaponUserCharacter Create(Vector3 position)
        {
            return _characterCreator.Create(position);
        }

        private ICharacterCreator<RangeWeaponUserCharacter> CreateCharacterCreator(
            UpdateService updateService,
            MovementControllerUpdateService movementControllerUpdateService,
            TargetProvider targetProvider)
        {
            MovementFactory movementFactory = new();
            HealthFactory healthFactory = new();

            CharacterFactory<RangeWeaponUserCharacter> characterFactory =
                new CharacterFactory<RangeWeaponUserCharacter>(
                    movementFactory,
                    healthFactory,
                    updateService);

            RandomTargetInputCreator movementInputCreator =
                new RandomTargetInputCreator(targetProvider);

            MovementInputFactory movementInputFactory =
                new MovementInputFactory(movementInputCreator);

            MovementControllerFactory movementControllerFactory =
                new MovementControllerFactory(movementControllerUpdateService);

            MovementControllerCharacterInitializer<RangeWeaponUserCharacter>
                movementInitializer =
                    new MovementControllerCharacterInitializer<RangeWeaponUserCharacter>(
                        movementInputFactory,
                        movementControllerFactory);

            DamageHitDataFactory damageHitDataFactory =
                new DamageHitDataFactory();

            HitRangeWeaponBuilder<DamageHitData, DamageHitDataConfig>
                damageWeaponBuilder =
                    new HitRangeWeaponBuilder<DamageHitData, DamageHitDataConfig>(
                        damageHitDataFactory);

            TeamDamageHitInteractService damageInteractService =
                new TeamDamageHitInteractService();

            DamageHitRangeWeaponCreator damageWeaponCreator =
                new DamageHitRangeWeaponCreator(
                    damageWeaponBuilder,
                    damageInteractService);

            HitRangeWeaponCreatorRegistry weaponCreatorRegistry =
                new HitRangeWeaponCreatorRegistry();

            weaponCreatorRegistry.Register(damageWeaponCreator);

            HitRangeWeaponFactory weaponFactory =
                new HitRangeWeaponFactory(weaponCreatorRegistry);

            HitRangeWeaponCharacterInitializer<RangeWeaponUserCharacter>
                weaponInitializer =
                    new HitRangeWeaponCharacterInitializer<RangeWeaponUserCharacter>(
                        weaponFactory);

            ICharacterCreator<RangeWeaponUserCharacter> creator =
                new CharacterCreator<RangeWeaponUserCharacter>(
                    characterFactory,
                    _prefab,
                    _characterConfig);

            creator =
                new MovementControllerCharacterCreator<RangeWeaponUserCharacter>(
                    creator,
                    movementInitializer,
                    _movementInputConfig);

            creator =
                new HitRangeWeaponCharacterCreator<RangeWeaponUserCharacter>(
                    creator,
                    weaponInitializer,
                    _weaponConfig);

            return creator;
        }
    }
}