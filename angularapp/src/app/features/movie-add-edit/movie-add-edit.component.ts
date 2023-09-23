import { Component, OnInit, Input } from '@angular/core';
import { Movie } from 'src/app/core/models/movie.model';
import { MovieService } from 'src/app/core/services/movie.service';


@Component({
  selector: 'app-movie-add-edit',
  templateUrl: './movie-add-edit.component.html',
  styleUrls: ['./movie-add-edit.component.scss']
})

export class MovieAddEditComponent {
@Input() movie! : Movie;

existsError : boolean = false;

constructor(private readonly movieService: MovieService) { }

ngOnInit() {  
  if (!this.movie){    
    this.movie = { id: 0 } as Movie;
  }
  else {

  }
}

onError(exists: boolean) {
  if (exists === true){
    alert('Unable to save your changes: This movie already exists. Please try a different name');
  } else {    
    alert('An error occurred while trying to save your changes, please try again');
  }
}

clearExistsError() {
  this.existsError = false;
}

onSubmit() {
  
  if (confirm("Are you sure you want to save your changes?")){
    
    this.movieService.exists(this.movie.name)
    .subscribe({
      next: (data: boolean) => {
        console.log('finished checking if exists, result returned');
        let movieExists : boolean = data;

        if (movieExists === true) {
          this.existsError = true;
          this.onError(true);
        } else {
          this.existsError = false;
    
          if (this.movie.id == 0){
            console.log("going to call create", this.movie);
            this.movieService.create(this.movie);
            console.log("called create");
          } else {
            console.log("going to call update", this.movie);
            this.movieService.update(this.movie);
            console.log("called update");
          }
        }

      },
      error: (e) => { 
        console.error(e);
        this.onError(false);
      }
    });
    
  }
}

}

