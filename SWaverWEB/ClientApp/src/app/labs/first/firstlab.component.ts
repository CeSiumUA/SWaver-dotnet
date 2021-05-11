import { Component, OnInit } from '@angular/core';
import { utils } from 'protractor';
import { MetricPrefixes, Utilities } from '../../../math/values';

@Component({
    selector: 'firstlab-app',
    templateUrl: './firstlab.component.html',
    styleUrls: ['./firstlab.component.css']
})
export class FirstLabComponent implements OnInit{

    public isDistanceSetMode = true;

    public frequency: number = 50;
    public frequencyMap: string = 'M';
    
    public transmitterPower: number = 10;
    public transmitterPowerMap: string = 'One';

    public transmitterDirectionalFactor = 3;
    public transmitterSWR = 1.2;

    public receiverDirectionalFactor = 6;
    public receiverSWR = 1.5;

    public transmitterLinearAttenuation = 0.01;
    public transmitterAntennaLength = 25;
    public transmitterAntennaLengthMap = 'One';

    public receiverLinearAttenuation = 0.02;
    public receiverAntennaLength = 20;
    public receiverAntennaLengthMap = 'One';

    public distance = 10;
    public distanceMap = 'k';

    public receiverSensitivity = -40;

    constructor(){

    }
    public get calcSetMode(): string{
        return this.isDistanceSetMode ? 'Задання відстані' : 'Задання чутливості приймача';
    }
    public get valuesMap(): string[]{
        let valsmap = Object.keys(MetricPrefixes)
        .filter(val => isNaN(Number(val)) === false)
        .map(key => MetricPrefixes[Number(key)]);
        return valsmap;
    }
    public get ReceiverInputPower(): number{
        return 0;
    }
    public get TransmitterEfficiency(): number{
        return 0;
    }
    public get EffectiveReceiverSquare(): number{
        return 0;
    }
    public get ReceiverEfficiency(): number{
        return 0;
    }
    public showValue(val: number | string): string{
        return val.toString();
    }
    ngOnInit(): void{
    }
}