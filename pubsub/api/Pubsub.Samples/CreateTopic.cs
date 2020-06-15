﻿// Copyright 2020 Google Inc.
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

// [START pubsub_create_topic]

using Google.Cloud.PubSub.V1;
using Grpc.Core;

public class CreateTopicSample
{
    public Topic CreateTopic(string projectId, string topicId)
    {
        PublisherServiceApiClient publisher = PublisherServiceApiClient.Create();
        TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);

        Topic result = null;
        try
        {
            result = publisher.CreateTopic(topicName);
        }
        catch (RpcException e) when (e.Status.StatusCode == StatusCode.AlreadyExists)
        {
            // Already exists.  That's fine.
        }
        return result;
    }
}
// [END pubsub_create_topic]
