﻿using pkg_context.Validations;

namespace pkg_context.Entities;

public sealed class UserGroup : BaseEntity
{
    public UserGroup(int? quantityMaxUser, string description, int number) : base(number)
    {
        ValidateStringAndLength.Validate(description, 255, "Informe a descrição!");
        if (quantityMaxUser != null)
            ValidateNumberZero.Validate(quantityMaxUser.Value, "Quantidade de usuários deve ser maior que zero!");
        QuantityMaxUser = quantityMaxUser;
        Description = description;
    }

    public int? QuantityMaxUser { get; private set; }
    public string Description { get; private set; }
    public List<PermissionsGroup> PermissionsGroups { get; set; } = new();
}
