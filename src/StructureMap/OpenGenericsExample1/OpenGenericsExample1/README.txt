This example demonstrates how to register an open generic type.

Scenario:

	You have an interface of typoe IRepository<T> along with one concrete
	implementation of type ConcreteRepository<T>.  You would like any request
	for IRepository<T> to resolve to ConcreteRepositry<T>.  For example, given
	some type depends upon an IRepository<Fruit>, you would like to resolve
	to ConcreteRepository<Fruit>.  You could register these types explicitly,
	but StructureMap allows you to declare one registration which allows you to
	inject an IRepository<T> for any value T.