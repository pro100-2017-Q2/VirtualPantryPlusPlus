namespace ProjectPantryPlusPlus
{
    partial class RecipePopUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipePopUp));
            this.label4 = new System.Windows.Forms.Label();
            this.recipeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.authorBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.prepTimeBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.instructionsBox = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ingredientsBox = new System.Windows.Forms.RichTextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.servingSizeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Recipe Name:";
            // 
            // recipeName
            // 
            this.recipeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeName.ForeColor = System.Drawing.Color.SlateGray;
            this.recipeName.Location = new System.Drawing.Point(16, 30);
            this.recipeName.Name = "recipeName";
            this.recipeName.Size = new System.Drawing.Size(163, 20);
            this.recipeName.TabIndex = 1;
            this.recipeName.Text = "Mac & Cheese";
            this.recipeName.Click += new System.EventHandler(this.recipeBoxClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Author";
            // 
            // authorBox
            // 
            this.authorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.authorBox.Location = new System.Drawing.Point(16, 84);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(131, 20);
            this.authorBox.TabIndex = 3;
            this.authorBox.Text = "Gordon Ramsay";
            this.authorBox.Click += new System.EventHandler(this.authorBoxClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Prep Time: ";
            // 
            // prepTimeBox
            // 
            this.prepTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepTimeBox.ForeColor = System.Drawing.Color.Gray;
            this.prepTimeBox.Location = new System.Drawing.Point(16, 134);
            this.prepTimeBox.Name = "prepTimeBox";
            this.prepTimeBox.Size = new System.Drawing.Size(131, 20);
            this.prepTimeBox.TabIndex = 5;
            this.prepTimeBox.Text = "15 minutes";
            this.prepTimeBox.Click += new System.EventHandler(this.prepBoxClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 388);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Instructions:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Choose From Pantry";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GoToPantryClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Ingredients:";
            // 
            // instructionsBox
            // 
            this.instructionsBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.instructionsBox.Location = new System.Drawing.Point(16, 423);
            this.instructionsBox.Name = "instructionsBox";
            this.instructionsBox.Size = new System.Drawing.Size(330, 133);
            this.instructionsBox.TabIndex = 11;
            this.instructionsBox.Text = resources.GetString("instructionsBox.Text");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(304, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Photo: (Optional)";
            // 
            // ingredientsBox
            // 
            this.ingredientsBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ingredientsBox.Location = new System.Drawing.Point(16, 195);
            this.ingredientsBox.Name = "ingredientsBox";
            this.ingredientsBox.Size = new System.Drawing.Size(211, 96);
            this.ingredientsBox.TabIndex = 13;
            this.ingredientsBox.Text = "Elbow macaroni, 2 cups\nShredded cheddar, 2 Cups\nButter(optional), 2 tablespoons\nS" +
    "alt, to taste\nPepper, to taste";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(421, 593);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Serving Size: ";
            // 
            // servingSizeBox
            // 
            this.servingSizeBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.servingSizeBox.Location = new System.Drawing.Point(107, 319);
            this.servingSizeBox.Name = "servingSizeBox";
            this.servingSizeBox.Size = new System.Drawing.Size(100, 20);
            this.servingSizeBox.TabIndex = 16;
            this.servingSizeBox.Text = "2";
            // 
            // RecipePopUp
            // 
            this.ClientSize = new System.Drawing.Size(529, 628);
            this.Controls.Add(this.servingSizeBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.ingredientsBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.instructionsBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.prepTimeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.authorBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.recipeName);
            this.Controls.Add(this.label4);
            this.Name = "RecipePopUp";
            this.Text = "Add a Recipe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox recipeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox authorBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox prepTimeBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox instructionsBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox ingredientsBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox servingSizeBox;
    }
}