function UpdateURLAdd(){
    let formData = "/Note/AddPage";

    console.log(formData)

    history.pushState(formData, null, formData)
}