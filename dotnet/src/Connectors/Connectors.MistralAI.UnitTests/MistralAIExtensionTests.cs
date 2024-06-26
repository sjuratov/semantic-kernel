﻿// Copyright (c) Microsoft. All rights reserved.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.MistralAI;
using Microsoft.SemanticKernel.Embeddings;
using Xunit;

namespace SemanticKernel.Connectors.MistralAI.UnitTests;

/// <summary>
/// Unit tests for <see cref="MistralAIServiceCollectionExtensions"/> and <see cref="MistralAIKernelBuilderExtensions"/>.
/// </summary>
public class MistralAIExtensionTests
{
    [Fact]
    public void AddMistralChatCompletionToServiceCollection()
    {
        // Arrange
        var collection = new ServiceCollection();
        collection.AddMistralChatCompletion("model", "apiKey");

        // Act
        var kernelBuilder = collection.AddKernel();
        var kernel = collection.BuildServiceProvider().GetRequiredService<Kernel>();
        var service = kernel.GetRequiredService<IChatCompletionService>();

        // Assert
        Assert.NotNull(service);
        Assert.IsType<MistralAIChatCompletionService>(service);
    }

    [Fact]
    public void AddMistralTextEmbeddingGenerationToServiceCollection()
    {
        // Arrange
        var collection = new ServiceCollection();
        collection.AddMistralTextEmbeddingGeneration("model", "apiKey");

        // Act
        var kernelBuilder = collection.AddKernel();
        var kernel = collection.BuildServiceProvider().GetRequiredService<Kernel>();
        var service = kernel.GetRequiredService<ITextEmbeddingGenerationService>();

        // Assert
        Assert.NotNull(service);
        Assert.IsType<MistralAITextEmbeddingGenerationService>(service);
    }

    [Fact]
    public void AddMistralChatCompletionToKernelBuilder()
    {
        // Arrange
        var collection = new ServiceCollection();
        var kernelBuilder = collection.AddKernel();
        kernelBuilder.AddMistralChatCompletion("model", "apiKey");

        // Act
        var kernel = collection.BuildServiceProvider().GetRequiredService<Kernel>();
        var service = kernel.GetRequiredService<IChatCompletionService>();

        // Assert
        Assert.NotNull(service);
        Assert.IsType<MistralAIChatCompletionService>(service);
    }

    [Fact]
    public void AddMistralTextEmbeddingGenerationToKernelBuilder()
    {
        // Arrange
        var collection = new ServiceCollection();
        var kernelBuilder = collection.AddKernel();
        kernelBuilder.AddMistralTextEmbeddingGeneration("model", "apiKey");

        // Act
        var kernel = collection.BuildServiceProvider().GetRequiredService<Kernel>();
        var service = kernel.GetRequiredService<ITextEmbeddingGenerationService>();

        // Assert
        Assert.NotNull(service);
        Assert.IsType<MistralAITextEmbeddingGenerationService>(service);
    }
}
