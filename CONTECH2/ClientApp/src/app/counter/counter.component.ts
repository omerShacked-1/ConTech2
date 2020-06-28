import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent implements OnInit {
  public currentCount = 0;
  private checkoutForm: FormGroup;
  private tags = ["a", "b", "c"];
  private skills = new FormArray([]);
  constructor(private formBuilder: FormBuilder) { }
  public incrementCounter() {
    this.currentCount++;
  }
  ngOnInit() {
    this.checkoutForm = this.formBuilder.group({
      name: '',
      array: [{userID: 0,tagID:0}]
    });

  }
  addSkill() {
    const group = new FormGroup({
      level: new FormControl(''),
      name: new FormControl('')
    });
    this.skills.push(group);
  }
  removeSkill(i: number) {
    this.skills.removeAt(i);
  }
  prepend() {
    this.skills.insert(0, new FormControl(''));
  }
  clear() {
    this.skills.clear();
  }
  replace() {
    this.skills.setControl(0, new FormControl(''));
  }
  onSubmit() {
    this.checkoutForm.reset();
    console.warn("Your user added");
  }
}
