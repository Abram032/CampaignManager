import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { categoryStore } from '../../stores/categoryStore';
import { 
  Column,
  StringLengthRule,
  RequiredRule
} from 'devextreme-react/data-grid';

const columns = (
  [
    <Column dataField='id' caption='Id' dataType='number' allowEditing={false} />,
    <Column dataField='name' caption='Name' dataType='string'>
      <RequiredRule />
      <StringLengthRule min={1} max={100} />
    </Column>
  ]
);

export class Categories extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <DataGridExp columns={columns} store={categoryStore}/>
      </>
    );
  }
};

export default Categories;