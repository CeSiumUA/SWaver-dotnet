import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ChartDataset } from 'chart.js';
import { ChartConfiguration } from 'chart.js';
import { /* ChartDataSets, */ ChartOptions, ChartType, Chart, registerables } from 'chart.js';

import { GraphPoint } from '../models/GraphPoint';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private baseUrl: string = '';
  private points: GraphPoint[] = [];
  public get labels(): string[]{
    const pointsCollection = this.points.map(pnt => pnt.x.toString());
    return pointsCollection;
  }
  public get datasets(): ChartDataset[]{
    const pointsCollection = [{data: [1, 2, 3, 4, 5], label: 'test'}]; //[{data: this.points.map(pnt => pnt.y), label: 'Результуючий графік'}];
    return pointsCollection;
  }
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string){
    Chart.register(...registerables);
    this.baseUrl = baseUrl;
  }
  private drawGraph(): void{
    const config: ChartConfiguration = {
      type: 'line',
      data: {
        labels: this.labels,
        datasets: [{
          label: 'Результуючий графік',
          backgroundColor: 'rgb(255, 90, 132)',
          borderColor: 'rgb(255, 90, 132)',
          data: this.points.map(pnt => pnt.y),
        }]
      },
      options: {
        scales: {
          y: {
              beginAtZero: true
          }
      }
      }
    };
    const context = (document.getElementById('testCanvas') as HTMLCanvasElement).getContext('2d');
    if(context) { 
      const myChart = new Chart(
        context,
        config
      );
    }
  }
  ngOnInit(): void{
    this.httpClient.get(`${this.baseUrl}thirdlabcalculation/getgraphdata`)
      .subscribe((result) => {
        this.points = result as GraphPoint[];
        this.drawGraph();
      });
  }

  public lineChartType: ChartType = 'line';
  //public lineChartLegend = true;
  /* public lineChartColors: Color[] = [
    { // red
      backgroundColor: 'rgba(255,0,0,0.3)',
      borderColor: 'red',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    }
  ]; */
}
