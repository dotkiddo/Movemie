import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/core/models/category.model';
import { Movie } from 'src/app/core/models/movie.model';
import { CategoriesService } from 'src/app/core/services/categories.service';
import { MovieService } from 'src/app/core/services/movie.service';
//import { MatAutocompleteModule } from '@angular/material/autocomplete';


@Component({
  selector: 'app-movie-add-edit',
  templateUrl: './movie-add-edit.component.html',
  styleUrls: ['./movie-add-edit.component.scss']
})

export class MovieAddEditComponent {
@Input() movie! : Movie;
public categories: Category[] = []
public movieCategory: string = ""
public isOtherSelected: boolean = false


constructor(
  private readonly categoriesService: CategoriesService,
  private readonly movieService: MovieService) { }

ngOnInit() {
  this.categoriesService.getAll().subscribe((data) => {
    this.categories = data;
  });

  if (this.movie){
    this.movieCategory = this.movie.category;
  }
  else{
    this.movie = { } as Movie;
  }
}

onCategoryChanged() : void {
  this.isOtherSelected = this.movieCategory === "Other";
  if (this.isOtherSelected) this.movieCategory = "";
}

onSaveClicked() {
  
  if (confirm("Are you sure you want to save your changes?")){
    
    // if isOtherSelected create new caegory, and then assign the new id accordingly???

    alert("yes:" + this.movie.id);
    if (this.movie.id) { // update movie
      console.log("going to call update");
      this.movieService.update(this.movie);
      console.log("called update");

    }
    else { // create new movie
      console.log("going to call create");

      // this.movie.Name = 'test';
      // this.movie.category = 'test';
      // this.

      console.log(this.movie);
      this.movieService.create(this.movie);
      console.log("called create")
    }
    
  }
}

}


//#error // on this page still functionality of the save button -> check required?? check confirmation dialog??
// as well as create category...