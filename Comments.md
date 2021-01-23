ProductApplicationService top 5 concers:

1. All products services are processed in one method / Need to separate and use Factory pattern
2. CompanyDataRequest instance creation code and returning code are duplicated
    / I'd prefer to use automapper but.. Backwards compatibility - there are no ways to use Automapper static API and Profiles registration needed
3. Errors from Application Result are not processed
4. Validation
5. Need to avoid dependency from external services,
    because for every different service that the external library might come up with,
    the ProductApplicationService will get extra parameters

*Returns only Application Id, I'd prefer to create Response object, but we need to provide Backwards compatibility
*Need to request the External services refactoring for providing async operations