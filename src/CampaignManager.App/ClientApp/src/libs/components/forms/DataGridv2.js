import React, { Component } from 'react';
import { 
    DataGrid, 
    Column, 
    Editing, 
    Scrolling, 
    Lookup, 
    Summary, 
    TotalItem, 
    Paging, 
    Pager, 
    Grouping, 
    GroupPanel,
    FilterRow,
    HeaderFilter,
    SearchPanel,
    ColumnChooser, 
    ColumnFixing,
    MasterDetail,
    RequiredRule,
    PatternRule,
    StringLengthRule
} from 'devextreme-react/data-grid';
import DataSource from 'devextreme/data/data_source';
import { coalitionStore } from '../../../stores/coalitionStore';

function onRowUpdating(options) {
    options.newData = {...options.oldData, ...options.newData };
    debugger;
};

export class DataGridv2 extends Component {
    constructor(props) {
        super(props);
        debugger;
        this.state = {
            columns: this.props.columns,
            rows: this.props.rows ?? [],
            grouping: this.props.grouping ?? [],
            currentPage: this.props.currentPage ?? 1,
            pageSize: this.props.pageSize ?? 10,
            dataSource: coalitionStore.store,
            refreshMode: 'reshape',
            autoExpandAll: false,
            showFilterRow: true,
            showHeaderFilter: true,
            currentFilter: 'auto'
        }
    }

    dataSource = new DataSource({
        store: this.props.store,
        reshapeOnPush: true
    });

    renderColumns = () => {
        debugger
        let _columns = [];
        this.props.columns.forEach(column => {
            let _column = (
                <Column 
                    dataField={column.dataField} 
                    dataType={column.dataType || 'string'} 
                    caption={column.caption || column.dataField}
                    allowEditing={column.isEditable || true} 
                    visible={column.isVisible || true}
                >
                    {column.isRequired ? <RequiredRule /> : null}
                    {column.hasPattern ? <PatternRule pattern={column.pattern} /> : null}
                    {column.hasLenghtRule ? <StringLengthRule min={column.minLength} max={column.maxLength} /> : null}
                </Column>
            );
            _columns.push(_column);
        });
        return _columns.join('');
    }

    detail = () => {
        return(
            <div>deatils</div>
        );
    }

    render() {
        debugger;
        return (
            <>
                <DataGrid
                    dataSource={this.dataSource}
                    repaintChangesOnly={true}
                    showBorders={true}
                    showColumnLines={true}
                    showRowLines={true}
                    rowAlternationEnabled={true}
                    onRowUpdating={onRowUpdating}
                    allowColumnReordering={true}
                    allowColumnResizing={true}
                    columnAutoWidth={true}
                    //defaultColumns={this.state.columns}
                >
                    <Editing
                        refreshMode={this.state.refreshMode}
                        mode="cell"
                        allowAdding={true}
                        allowDeleting={true}
                        allowUpdating={true}
                    />
                    <ColumnChooser enabled={true} />
                    <ColumnFixing enabled={true} />
                    <FilterRow visible={this.state.showFilterRow}
                        applyFilter={this.state.currentFilter} />
                    <HeaderFilter visible={this.state.showHeaderFilter} />
                    <SearchPanel visible={true}
                        width={240}
                        placeholder="Search..." />
                    <GroupPanel visible={true} />
                    <Grouping autoExpandAll={this.state.autoExpandAll} />
                    <Paging defaultPageSize={10} />
                    <Pager
                        showPageSizeSelector={true}
                        allowedPageSizes={[5, 10, 25, 50]}
                        showInfo={true} 
                    />
                    <Scrolling
                        mode="virtual"
                    />
                    <MasterDetail 
                        enabled={true}
                        component={this.detail}
                    />
                    {this.renderColumns()}
                </DataGrid>
            </>
        );
    }
}

export default DataGridv2;
