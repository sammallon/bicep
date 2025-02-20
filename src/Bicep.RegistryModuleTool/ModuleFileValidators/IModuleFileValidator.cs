// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Bicep.RegistryModuleTool.ModuleFiles;
using System;

namespace Bicep.RegistryModuleTool.ModuleFileValidators
{
    public interface IModuleFileValidator
    {
        void Validate(VersionFile file) => throw new NotImplementedException();

        void Validate(MetadataFile file) => throw new NotImplementedException();

        void Validate(MainBicepFile file) => throw new NotImplementedException();

        void Validate(MainArmTemplateFile file) => throw new NotImplementedException();

        void Validate(MainArmTemplateParametersFile file) => throw new NotImplementedException();

        void Validate(ReadmeFile file) => throw new NotImplementedException();
    }
}
