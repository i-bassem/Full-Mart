import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListProuctsComponent } from './list-proucts.component';

describe('ListProuctsComponent', () => {
  let component: ListProuctsComponent;
  let fixture: ComponentFixture<ListProuctsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListProuctsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListProuctsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
