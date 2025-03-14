// Copyright 2025 Nitro Agility S.r.l.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;

namespace Permguard.AzReq
{
    // ResourceBuilder is the builder for the resource object.
    public class ResourceBuilder
    {
        private Permguard.Resource resource;

        // Constructor to initialize ResourceBuilder with a type (kind).
        public ResourceBuilder(string kind)
        {
            resource = new Permguard.Resource
            {
                Type = kind
            };
            resource.Properties = new Dictionary<string, object>();
        }

        // WithID sets the id of the resource.
        public ResourceBuilder WithID(string id)
        {
            resource.ID = id;
            return this;
        }

        // WithProperty sets a property of the resource.
        public ResourceBuilder WithProperty(string key, object value)
        {
            resource.Properties[key] = value;
            return this;
        }

        // Build constructs and returns the final Resource object.
        public Permguard.Resource Build()
        {
            var instance = new Permguard.Resource
            {
                ID = resource.ID,
                Type = resource.Type,
                Properties = DeepCopy(resource.Properties)
            };
            return instance;
        }

        // Helper method to deep copy the properties dictionary.
        private Dictionary<string, object> DeepCopy(Dictionary<string, object> source)
        {
            var copy = new Dictionary<string, object>();
            foreach (var key in source.Keys)
            {
                copy[key] = source[key];
            }
            return copy;
        }
    }
}
