// Aspire TypeScript AppHost
// For more information, see: https://aspire.dev

import { createBuilder } from './.aspire/modules/aspire.mjs';

const builder = await createBuilder();

// ABP single-layer MVC app (AbpTempSimpleApp).
// - SQLite is file-based (ConnectionStrings:Default), so there is no container/DB resource to model.
// - The HTTPS port stays fixed at 44370 (from launchSettings.json) because OpenIddict's
//   AuthServer:Authority and App:SelfUrl are hardcoded to https://localhost:44370; an
//   Aspire-managed random port would break OIDC/login flows.
await builder
    .addProject('abpapp', './AbpTempSimpleApp/AbpTempSimpleApp.csproj')
    .withExternalHttpEndpoints();

await builder.build().run();