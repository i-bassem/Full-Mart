import { Component } from '@angular/core';

@Component({
  selector: 'app-libraries',
  templateUrl: './libraries.component.html',
  styleUrls: ['./libraries.component.css']
})
export class LibrariesComponent {

  passvalue="";
  values: string[]=[];
  value = new Date(2000/5/25);

  data: any;
  chartOptions: any;
  // subscription: Subscription;
  // config: AppConfig;  
  // constructor(private configService: AppConfigService) {}

  ngOnInit() {
    this.data = {
        labels: ['A','B','C'],
        datasets: [
            {
                data: [300, 50, 100],
                backgroundColor: [
                    "#FF6384",
                    "#36A2EB",
                    "#FFCE56"
                ],
                hoverBackgroundColor: [
                    "#FF6384",
                    "#36A2EB",
                    "#FFCE56"
                ]
            }
        ]
    };
  }
    

}
