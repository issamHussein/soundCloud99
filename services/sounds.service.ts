import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { debug } from 'console';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class SoundsService {
  sound:any=[{}];
  display_Image:any;
display_song:any;
amtOfSounds:any=[{}]
// downloadedSound:boolean=false;
downloadedSound:any=[{}];
uploadedsounds:any=[{}]
oneSound:any=[{}]
SoundDownloadedByTheUser:any=[{}]
  constructor(private http:HttpClient,
    private spinner :NgxSpinnerService,private toastr:ToastrService, private router: Router ) { }



 getSoundByCategoryId(id:number){
     //show spinner 
     this.spinner.show();
     //hits Api 
       this.http.get('https://localhost:44338/Sounds/GetByCATEGORYID/'+id).subscribe((res)=>{
       this.sound=res;
       
       this.spinner.hide();
       this.toastr.success('Data Retrieved !!');
     },err=>{
       this.spinner.hide();
       this.toastr.error(err.message, err.status);
     })
     //hide spinner
     //res --> show toastr
  }


createSound(body:any){
  this.spinner.show();
  
  body.image=this.display_Image;
body.song=this.display_song;
debugger
  this.http.post('https://localhost:44338/Sounds/CreateSounds',body).subscribe((res)=>{
    
  this.spinner.hide();
    this.toastr.success('saved Successfully :)');
  },error=>{
    this.spinner.hide();
    this.toastr.error(error.status,error.message);
  })
  window.location.reload();

}

uploadAttachment(file:FormData){
  this.http.post('https://localhost:44338/Sounds/UploadImage/',file)
  .subscribe((res:any)=>{
    this.display_Image=res.image;
    console.log(this.display_Image);
    
    
  },err=>{
    this.toastr.error(err.status,err.message);
  })
}


uploadSongAttachment(file:FormData){
  
  this.http.post('https://localhost:44338/Sounds/UploadSongs/',file)
  .subscribe((res:any)=>{
    this.display_song=res.song;
    console.log(this.display_song);
    
    
  },err=>{
    this.toastr.error(err.status,err.message);
  })
}






updateSounds(body:any){
  
  body.image=this.display_Image;
  body.song=this.display_song;
  
  this.http.put('https://localhost:44338/Sounds/UpdateSOUNDS/',body).subscribe((res)=>{
    
    this.toastr.success('updated Successfully :)');

  },err=>{
    this.toastr.error(err.status,err.message);
  })
  window.location.reload();

}



GetAllSounds(){
  //show spinner 
  this.spinner.show();
  //hits Api 
    this.http.get('https://localhost:44338/Sounds/GetAllSounds').subscribe((res)=>{
    this.sound=res;
    this.spinner.hide();
    this.toastr.success('Data Retrieved !!');
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  })

}

delete(id:number){
  
  this.http.delete('https://localhost:44338/Sounds/DeleteSOUNDS/'+id).subscribe((res)=>{
    this.toastr.success('Deleted Successfully :)');
  },err=>{
    this.toastr.error(err.status,err.message);
  })
  window.location.reload();

}


getSoundBySoundId(id:number){
  //show spinner 
  this.spinner.show();
  //hits Api 
  
    this.http.get('https://localhost:44338/Sounds/GetBySOUNDId/'+id).subscribe((res)=>{
    this.oneSound=res;
    this.spinner.hide();
    console.log(this.oneSound);
    
  
    this.toastr.success('Data Retrieved !!');
  },
  err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  })
}



// buySound(body:any){
//   this.spinner.show();
  
//   
//   this.http.post('https://localhost:44338/Sounds/buySound',body).subscribe((res)=>{
    
//   this.spinner.hide();
//     this.toastr.success('bought Successfully :)');
//   },error=>{
//     this.spinner.hide();
//     this.toastr.error(error.status,error.message);
//   })
// }




GetTop10Sounds(){
  //show spinner 
  this.spinner.show();
  //hits Api 
    this.http.get('https://localhost:44338/Sounds/GetTOP10Sounds').subscribe((res)=>{
    this.sound=res;
    console.log(this.sound);
    
    this.spinner.hide();
    this.toastr.success('Data Retrieved !!');
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  })

}












check(body:any){
  // this.spinner.show();
  this.spinner.show();

  
  this.http.post('https://localhost:44338/Sounds/Check',body).subscribe((res) =>{
    
    //  this.downloadedSound=res;
  // this.spinner.hide();
  this.downloadedSound=res
  
  this.spinner.hide();
  this.toastr.success('Data Retrieved !!');

  },error=>{
    this.spinner.hide();
    this.toastr.error(error.status,error.message);
  })

  

}








createSoundByUser(body:any){
  this.spinner.show();
  
  body.image=this.display_Image;
body.song=this.display_song;

  this.http.post('https://localhost:44338/Sounds/CreateSoundsByUsers',body).subscribe((res)=>{
    
  this.spinner.hide();
    this.toastr.success('saved Successfully :)');
  },error=>{
    this.spinner.hide();
    this.toastr.error(error.status,error.message);
  })
window.location.reload();
}












soundsUploadedByTheUser(id:number){
  //show spinner 
  this.spinner.show();
  //hits Api 
  
    this.http.get('https://localhost:44338/Sounds/soundsUploadedByTheUser/'+id).subscribe((res)=>{
    this.uploadedsounds=res;
    console.log(this.uploadedsounds);
    
    this.spinner.hide();
    this.toastr.success('Data Retrieved !!');
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  })
}




updateSoundsByUser(body:any){
  body.categoryID=181
  body.image=this.display_Image;
  body.song=this.display_song;
  debugger
  this.http.put('https://localhost:44338/Sounds/UpdateSoundsByUsers',body).subscribe((res)=>{
    
    this.toastr.success('updated Successfully :)');

  },err=>{
    this.toastr.error(err.status,err.message);
  })
  window.location.reload();

}





AmountOfSoundsUploadedByTheUser(id:number){
  //show spinner 
  this.spinner.show();
  //hits Api 
  
    this.http.get('https://localhost:44338/Sounds/AmountOfSoundsUploadedByTheUser/'+id).subscribe((res)=>{
    this.amtOfSounds=res;
    
    this.spinner.hide();
    this.toastr.success('Data Retrieved !!');
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  })
}








//ADMEN SOUNDS SEARCH
getSoundBySoundName(name:any){
  //show spinner 
  this.spinner.show();
  //hits Api 
  console.log(name);
    this.http.get('https://localhost:44338/Sounds/GetBySOUNDName/'+name).subscribe((res)=>{
    this.sound=res;
    this.spinner.hide();
    console.log(this.sound);
  
    this.toastr.success('Data Retrieved !!');
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  })
}








//user Sounds Search
getSoundBySoundNameForUser(name:any){
  //show spinner 
  this.spinner.show();
  //hits Api 
  console.log(name);
    this.http.get('https://localhost:44338/Sounds/GetBySOUNDName/'+name).subscribe((res)=>{
    this.uploadedsounds=res;
    this.spinner.hide();
    console.log(this.sound);
  
    this.toastr.success('Data Retrieved !!');
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  })
}


soundsDownloadedByTheUser(id:number){
  //show spinner 
  this.spinner.show();
  //hits Api 
  
    this.http.get('https://localhost:44338/Sounds/SoundDownloadedByTheUser/'+id).subscribe((res)=>{
    this.SoundDownloadedByTheUser=res;
    console.log(this.SoundDownloadedByTheUser);
    
    this.spinner.hide();
    this.toastr.success('Data Retrieved !!');
  },err=>{
    this.spinner.hide();
    this.toastr.error(err.message, err.status);
  })
}


}
