
```

on this one the strategy now:

1. DbUp.

2 -> identify/name all the calls that the front end will make and create them...

MoviesController
ListAll?
	-> what about the filter?

DeleteById
ListByRating

Create

Update/UpdateById



RatingsController??? or CategoriesController?
ListCountsByRating??? nee man....


think... if we do categories by id instead of by name.... then what??? 
then we need the ability to also pull in there.... so also a categorycontroller...


///

on the client side... identify the components


listmovies / movieslist / moviesgrid / moviesview
addEditmovies / moviesaddEdit

listratings/ratingslist / ratingsgrid / ratingsview

reports -> categoryrating

```







---


# Angularapp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.2.2.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
