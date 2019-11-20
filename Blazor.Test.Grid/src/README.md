# Blazor Test Grid

Sample generic components based on a grid.

Grid.razor - the top level Grid component
GridColumn.razor - A column definition component

## Sample

``` HTML
<Grid Data=@data Context="gridContext">
    <Columns Context="rowData">
        <GridColumn Data="@rowData?.ID"><img src="@rowData?.Avatar" width="64" height="64"/></GridColumn>
        <GridColumn Title="Name" Data="@rowData?.Handle"/>
        <GridColumn Data="@rowData?.UsesBlazor">@(rowData?.UsesBlazor ?? false ? "Yay!" : "Boo!")</GridColumn>
    </Columns>
</Grid>
```
This sample shows the use of strongly type data in child components and how to access row-level data inside a templated component.

## Known Issues

This is a quick sample - it is incomplete - not a re-usable grid component. For research only.